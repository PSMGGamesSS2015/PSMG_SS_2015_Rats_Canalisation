using UnityEngine;
using System.Collections;

public class RatMovement : MonoBehaviour
{

    public float rotationSpeed = 1f;
    public static float generalMovementSpeed = 3f;
    public float runSpeed = 5f;
    public float slowSpeed = 1f;
    public float movementSpeed = generalMovementSpeed;
	public static float generalJumpSpeed = 20f;
	public float jumpSpeed = generalJumpSpeed;
    public bool isGrounded = false;
    public bool isAtWall = false;
	public float godModeSpeed = 10f;
	public bool godModeActive = false;
	public float rageModeSpeed = 5f;
	public bool rageModeActive = false;
    //max Slope the Rat can jump of
    public float maxSlope = 60f;

    // Use this for initialization
    void Start()
    {
		transform.GetComponent<ParticleSystem>().enableEmission = false;
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
		checkZeroPoint ();
		GodMode ();
		Attack ();
		if (!godModeActive && !rageModeActive) {
			Run ();
			Sneak ();
			NormalizeSpeed ();
		} else {
			extremeHeal();
		}
    }

    void FixedUpdate()
    {
        float horizontalMouseInput = Input.GetAxis("Mouse X");
        float moveVertical = Input.GetAxis("Vertical");
        float moveHorizontal = Input.GetAxis("Horizontal");
        Turn(horizontalMouseInput);
		if (!GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<CameraMovement> ().firstPersonActive ()) {
			Move (moveHorizontal, moveVertical);
		}
    }

    private void Run()
    {
		int currentHunger = transform.GetComponent<Attributes>().GetCurrentHunger();
        if (Input.GetKeyDown(KeyCode.LeftControl) && currentHunger>0)
        {
            movementSpeed = runSpeed;
        }
    }

    public void Sneak()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            movementSpeed = slowSpeed;
        }
    }

    public void NormalizeSpeed()
    {
        if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.LeftShift))
        {
            movementSpeed = generalMovementSpeed;
        }
    }

    //called once per Collision per physics update
    //determines whether Rat is on the Ground
    //determines whether Rat is at a Wall 
    public void OnCollisionStay(Collision collision)
    {
        int layerMask = 1 << 8;
        layerMask = ~layerMask;
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.green);
            if (Vector3.Angle(contact.normal, Vector3.up) > 5f)
            {
                isGrounded = false;
            }
            else
            {
                isGrounded = true;
                break;
            }
        }
        RaycastHit hit;
        Debug.DrawRay(transform.position, -Vector3.up * .4f, Color.cyan);
        if (!isGrounded && Physics.Raycast(transform.position, -Vector3.up, out hit, 0.4f, layerMask))
        {
            isGrounded = true;
        }


        foreach (ContactPoint contact in collision.contacts)
        {
            if (Vector3.Angle(contact.normal, Vector3.up) < 85f)
            {
                isAtWall = false;
            }
            else
            {
                isAtWall = true;
                break;
            }
        }

        Debug.DrawRay(transform.position, transform.forward * .4f, Color.cyan);
        if (isAtWall && !Physics.Raycast(transform.position, transform.forward, out hit, 0.4f, layerMask))
        {
            isAtWall = false;
        }

    }


    public void OnCollisionExit(Collision collisionInfo)
    {
       // print("No longer in contact with " + collisionInfo.transform.name);
        isGrounded = false;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpSpeed);
        }
		if (Input.GetKeyDown(KeyCode.Space) && godModeActive)
		{
			isGrounded = false;
			GetComponent<Rigidbody>().AddForce(Vector3.up * jumpSpeed);
			
		}
    }

    private void Move(float horizontal, float vertical)
    {
        //can´t move while in the air and facing a wall to not get stuck
        if (!isGrounded && isAtWall)
        { }
        else
        {
            if (horizontal != 0 || vertical != 0)
            {
                Vector3 newPosition = transform.forward.normalized * vertical * movementSpeed * Time.deltaTime;
                newPosition += transform.right.normalized * horizontal * movementSpeed * Time.deltaTime;
                GetComponent<Rigidbody>().MovePosition(transform.position + newPosition);
            }
        }

    }

	private void Attack(){
		if (Input.GetMouseButtonDown(0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit)){
				if (hit.collider.tag == "Enemy"){
					hit.collider.enabled = false;
					Destroy(hit.collider);
				}
			}

		}
	}

	private void checkZeroPoint(){
		if (transform.position.y <= -50)
			GameObject.FindGameObjectWithTag("Player").GetComponent<Attributes>().Die();
	}

    private void Turn(float inputSignal)
    {
        float angle = inputSignal * rotationSpeed;
        transform.Rotate(transform.up * angle);
    }

	private void GodMode(){
		if (Input.GetKeyDown (KeyCode.L) && !PauseController.isPaused)  {
			if (godModeActive){
				godModeActive = false;
				movementSpeed = generalMovementSpeed;
			}
			else{
				godModeActive = true;
				movementSpeed = godModeSpeed;
			}
		}

	}

	public bool checkGodMode(){
		return godModeActive;
	}

	public bool checkRageMode(){
		return rageModeActive;
	}

	private void extremeHeal(){
		transform.GetComponent<Attributes>().ChangeLife(5);
	}

	public void gotPill(){
		godModeActive = false;
		rageModeActive = true;
		transform.GetComponent<ParticleSystem>().enableEmission = true;
		movementSpeed = rageModeSpeed;
	}

	public void deactivateRagemode(){
		rageModeActive = false;
		movementSpeed = generalMovementSpeed;
		transform.GetComponent<ParticleSystem>().enableEmission = false;
	}
	
}
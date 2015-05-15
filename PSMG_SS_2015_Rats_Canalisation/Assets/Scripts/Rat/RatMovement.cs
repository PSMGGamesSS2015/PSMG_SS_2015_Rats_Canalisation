using UnityEngine;
using System.Collections;

public class RatMovement : MonoBehaviour {
	
	public float rotationSpeed = 1f;
	public static float generalMovementSpeed = 3f;
    public float runSpeed = 5f;
    public float slowSpeed = 1f;
	public float movementSpeed = generalMovementSpeed;
	public float jumpSpeed = 20f;
	public float RayCastLength = .1f;
	public bool isGrounded = false;
    //max Slope the Rat can jump of
    public float maxSlope = 60f;

	// Use this for initialization
	void Start () {	
	}
	
	// Update is called once per frame
	void Update () {
		Jump ();
		Run();
		Sneak();
		NormalizeSpeed();
		
	}

	void FixedUpdate()
	{
		float horizontalInput = Input.GetAxis("Mouse X");
		float moveVertical = Input.GetAxis("Vertical");
		float moveHorizontal = Input.GetAxis ("Horizontal");
		Turn(horizontalInput);
        Move(moveHorizontal, moveVertical);
		//MoveHorizontal (moveHorizontal);
		//MoveVertical (moveVertical);
	}

    private void Run()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
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

    // sets isGrounded to true, if angle between the colliding vector and the upwards Vector is smaller than maxSlope
    // determins weather ground is jumpable
    public void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (Vector3.Angle(contact.normal, Vector3.up) < maxSlope){
                isGrounded = true;
            }
        }
    }

    public void OnCollisionExit()
    {
        isGrounded = false;
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpSpeed);
        }
    }

    private void Move(float horizontal, float vertical)
    {
        if (horizontal != 0 || vertical != 0)
        {
           Vector3 newPosition = transform.forward.normalized * vertical * movementSpeed * Time.deltaTime;
           newPosition += transform.right.normalized * horizontal * movementSpeed * Time.deltaTime;
           GetComponent<Rigidbody> ().MovePosition (transform.position + newPosition);
		}
    }
	

    /**
	private void MoveHorizontal(float horizontal)
	{
		if (horizontal != 0) {
			Vector3 newPosition = transform.right.normalized * horizontal * movementSpeed * Time.deltaTime;	
			GetComponent<Rigidbody> ().MovePosition (transform.position + newPosition);
		}
	}

	private void MoveVertical(float vertical){
		if (vertical != 0) {
			Vector3 newPosition2 = transform.forward.normalized * vertical * movementSpeed * Time.deltaTime;
			GetComponent<Rigidbody> ().MovePosition (transform.position + newPosition2);
		}
	}
     */
	
	private void Turn(float inputSignal)
	{
		float angle = inputSignal * rotationSpeed;
		transform.Rotate(transform.up * angle);
	}
	
	

}
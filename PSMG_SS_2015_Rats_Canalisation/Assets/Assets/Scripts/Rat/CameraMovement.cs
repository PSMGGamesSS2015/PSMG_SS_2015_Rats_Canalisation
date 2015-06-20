using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{

    //additianal distance to walls
    public float WallDamping = 0.4f;
    // The target we are following
    public Transform target;
    // The distance in the x-z plane to the target
    public float distance = 20.0f;
    // the height we want the camera to be above the target
    public float height = 5.0f;
    // How much we 
    public float Damping = 4.0f;
    public float rotationSpeed = 1f;

    // Default Value for is first person view active
    private bool firstPerson = false;

    void FixedUpdate()
    {
        // Early out if we don't have a target
        if (!target)
            return;

        //maybe used later 
        //transform.RotateAround(target.position, Vector3.left, verticalMouseInput * rotationSpeed);
		if (!firstPerson) {
			thirdPersonAttributes ();
		} else {
			firstPersonAttributes ();
		}

       
               
    }
	private void thirdPersonAttributes(){
		Vector3 CameraFinalPosition = new Vector3();
		Vector3 DirPlayerToCamera = new Vector3();
		CameraFinalPosition = target.position - (target.forward * (distance-WallDamping));
		CameraFinalPosition += Vector3.up * height;
		
		DirPlayerToCamera = CameraFinalPosition - target.position;
		DirPlayerToCamera.Normalize();
		
		Ray MyRay = new Ray(target.position, DirPlayerToCamera);
		RaycastHit HitInfo = new RaycastHit();
		Physics.Raycast(MyRay, out HitInfo, distance);
		if (HitInfo.collider != null)
		{
			if (HitInfo.distance < distance)
			{
				CameraFinalPosition.x += -DirPlayerToCamera.x * (distance - HitInfo.distance);
				CameraFinalPosition.y += DirPlayerToCamera.y * (distance - HitInfo.distance);
				CameraFinalPosition.z += -DirPlayerToCamera.z * (distance - HitInfo.distance);
			}
		}
		transform.position = Vector3.Lerp(transform.position, CameraFinalPosition, Time.deltaTime * Damping);
		transform.LookAt(target);
	}

	private void firstPersonAttributes(){
		float angleY = Input.GetAxis("Mouse Y") * rotationSpeed;
		float angleX = Input.GetAxis("Mouse X") * rotationSpeed;
		transform.Rotate(-angleY, angleX, 0);
		Vector3 CameraFinalPosition = new Vector3();
		CameraFinalPosition = target.position;
		CameraFinalPosition += Vector3.up * height;
		transform.position = Vector3.Lerp(transform.position, CameraFinalPosition, Time.deltaTime * Damping);
	}
	
	void Start(){
		GameObject.FindGameObjectWithTag ("Damage").GetComponent<CanvasGroup>().alpha = 0f;
		GameObject.FindGameObjectWithTag ("Lost").GetComponent<CanvasGroup>().alpha = 0f;

		Cursor.visible = false; 
		Screen.lockCursor = true;
	}

    void Update()
    {
        selectCameraPosition();
    }

    public void selectCameraPosition()
    {
        //Select the View Type
        if (Input.GetKeyDown(KeyCode.V))
        {
            if (!firstPerson)
                firstPerson = true;
            else
                firstPerson = false;
        }
    }

	public bool firstPersonActive() {
		return firstPerson;
	}
} 
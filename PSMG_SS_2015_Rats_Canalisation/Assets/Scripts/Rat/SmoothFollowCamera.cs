using UnityEngine;
using System.Collections;

public class SmoothFollowCamera : MonoBehaviour
{

    // The target we are following
    public Transform target;
    // The distance in the x-z plane to the target
    public float distance = 40.0f;
    // the height we want the camera to be above the target
    public float height = 7.0f;
    // How much we
    public float Damping = 4.0f;
	public float rotationSpeed = 1f;
	// Default Value for is first person view active
	public bool firstPerson = false;

    void LateUpdate()
    {
        // Early out if we don't have a target
        if (!target)
            return;
		
        Vector3 CameraFinalPosition = new Vector3();
        Vector3 DirPlayerToCamera = new Vector3();

		if (!firstPerson) {//Third Person Settings
			CameraFinalPosition = target.position-target.forward*2;
			CameraFinalPosition += Vector3.up * height;
		} else {//First Person Settings
			CameraFinalPosition = target.position;
		}

        DirPlayerToCamera = CameraFinalPosition - target.position;
        DirPlayerToCamera.Normalize();

        Ray MyRay = new Ray(target.position, DirPlayerToCamera);
        RaycastHit HitInfo = new RaycastHit();
        Physics.Raycast(MyRay, out HitInfo, distance);
        if (HitInfo.collider != null)
        {
            if (HitInfo.distance < distance)
            {
                CameraFinalPosition += -DirPlayerToCamera * (distance - HitInfo.distance);
            }
        }

        transform.position = Vector3.Lerp(transform.position, CameraFinalPosition, Time.deltaTime * Damping);
        transform.LookAt(target);
    }

	void Update(){
		upDown ();
		selectPosition ();
	}

	public void upDown (){//Move Camera up and down 
		float angle = Input.GetAxis("Mouse Y")*rotationSpeed;
		transform.Rotate (-angle,0,0);
	}

	public void selectPosition(){//Select the View Type
		if (Input.GetKeyDown (KeyCode.V)) {
			if(!firstPerson)
				firstPerson = true;
			else
				firstPerson = false;
		}
	}
}
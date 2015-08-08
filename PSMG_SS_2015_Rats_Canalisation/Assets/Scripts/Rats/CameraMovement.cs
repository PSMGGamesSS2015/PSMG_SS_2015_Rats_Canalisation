using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{

    //additianal distance to walls
    public float WallDamping = 0.4f;
    // The target we are following
    public Transform target;
    // The distance in the x-z plane to the target
    public float maxDistance = 20.0f;
    // the height we want the camera to be above the target
    public float height = 5.0f;
    // Delay to the Cameraadjustment
    public float Damping = 4.0f;

    //Final Position of the Camera
    Vector3 CameraFinalPosition = new Vector3();
    // directional normalized Vectors
    Vector3 DirPlayerToCamera = new Vector3();
    Vector3 DirCamToRightHelper = new Vector3();
    Vector3 DirCamToLeftHelper = new Vector3();
    Vector3 DirCamToTopHelper = new Vector3();

    //Empty Objects for early WallCollsion tests in the Up,Left and Right direction of the Camera
    Transform HitHelperRight, HitHelperLeft, HitHelperTop;

    //distance between player and camera and player and helper Empty Objects
    float checkDistanceRight, checkDistanceLeft, checkDistanceBack, checkDistanceTop;




    public float rotationSpeed = 1f;
    // Default Value for is first person view active
    public bool firstPerson = false;



    void Start()
    {
        HitHelperRight = GameObject.Find("HitHelperRight").GetComponent<Transform>();
        HitHelperLeft = GameObject.Find("HitHelperLeft").GetComponent<Transform>();
        HitHelperTop = GameObject.Find("HitHelperTop").GetComponent<Transform>();

        //What is this??? Mario pls fix :)
        GameObject.FindGameObjectWithTag("Damage").GetComponent<CanvasGroup>().alpha = 0f;
        GameObject.FindGameObjectWithTag("Lost").GetComponent<CanvasGroup>().alpha = 0f;
    }

    void FixedUpdate()
    {
        // Early out if we don't have a target
        if (!target)
            return;

        //maybe used later 
        //transform.RotateAround(target.position, Vector3.left, verticalMouseInput * rotationSpeed);

        //Camera gets positioned behind target by maxDistance - WallDamping and moved up by "height"
        CameraFinalPosition = target.position - (target.forward * (maxDistance - WallDamping));
        CameraFinalPosition += Vector3.up * height;


        //This standard Positions gets copied into 4 additional Vectors that get modified later
        Vector3 CameraPosCheckRight = CameraFinalPosition;
        Vector3 CameraPosCheckLeft = CameraFinalPosition;
        Vector3 CameraPosCheckBack = CameraFinalPosition;
        Vector3 CameraPosCheckTop = CameraFinalPosition;

        // 4 normalized Vectors for the direction to Camera and 3 Helper Empty Obejcts around the Camera
        DirPlayerToCamera = CameraFinalPosition - target.position;
        DirPlayerToCamera.Normalize();
        DirCamToRightHelper = HitHelperRight.position - target.position;
        DirCamToRightHelper.Normalize();
        DirCamToLeftHelper = HitHelperLeft.position - target.position;
        DirCamToLeftHelper.Normalize();
        DirCamToTopHelper = HitHelperTop.position - target.position;
        DirCamToTopHelper.Normalize();

        //4 Rays from the Player in the 4 directions above
        Ray RightHelperRay = new Ray(target.position, DirCamToRightHelper);
        Ray LeftHelperRay = new Ray(target.position, DirCamToLeftHelper);
        Ray TopHelperRay = new Ray(target.position, DirCamToTopHelper);
        Ray BackRay = new Ray(target.position, DirPlayerToCamera);

        //Those 4 Rays get drawn into the Scene View
        Debug.DrawRay(target.position, maxDistance * DirPlayerToCamera, Color.blue);
        Debug.DrawRay(target.position, maxDistance * DirCamToRightHelper, Color.red);
        Debug.DrawRay(target.position, maxDistance * DirCamToLeftHelper, Color.red);
        Debug.DrawRay(target.position, maxDistance * DirCamToTopHelper, Color.red);

        //4 RaycastHits to get the Wall Collision
        RaycastHit RightHitInfoHelper = new RaycastHit();
        RaycastHit LeftHitInfoHelper = new RaycastHit();
        RaycastHit TopHitInfoHelper = new RaycastHit();
        RaycastHit BackHitInfo = new RaycastHit();

        Physics.Raycast(RightHelperRay, out RightHitInfoHelper, maxDistance);
        Physics.Raycast(LeftHelperRay, out LeftHitInfoHelper, maxDistance);
        Physics.Raycast(TopHelperRay, out TopHitInfoHelper, maxDistance);
        Physics.Raycast(BackRay, out BackHitInfo, maxDistance);


        //The 4 possible Vectors for the Cameraposition get calculated
        //The StandardCameraPosition gets modified by differnce of the maxDistance and the Distance of the RaycastHit

        //for the back
        if (BackHitInfo.collider != null)
        {
            if (BackHitInfo.distance < maxDistance)
            {
                CameraPosCheckBack.x += -DirPlayerToCamera.x * (maxDistance - BackHitInfo.distance);
                CameraPosCheckBack.y += -DirPlayerToCamera.y * (maxDistance - BackHitInfo.distance);
                CameraPosCheckBack.z += -DirPlayerToCamera.z * (maxDistance - BackHitInfo.distance);
            }
        }

        //for the rightHelper
        if (RightHitInfoHelper.collider != null)
        {
            if (RightHitInfoHelper.distance < maxDistance)
            {
                CameraPosCheckRight.x += -DirPlayerToCamera.x * (maxDistance - RightHitInfoHelper.distance - WallDamping);
                CameraPosCheckRight.y += -DirPlayerToCamera.y * (maxDistance - RightHitInfoHelper.distance - WallDamping);
                CameraPosCheckRight.z += -DirPlayerToCamera.z * (maxDistance - RightHitInfoHelper.distance - WallDamping);
            }
        }

        //for the LeftHelper
        if (LeftHitInfoHelper.collider != null)
        {
            if (LeftHitInfoHelper.distance < maxDistance)
            {
                CameraPosCheckLeft.x += -DirPlayerToCamera.x * (maxDistance - LeftHitInfoHelper.distance - WallDamping);
                CameraPosCheckLeft.y += -DirPlayerToCamera.y * (maxDistance - LeftHitInfoHelper.distance - WallDamping);
                CameraPosCheckLeft.z += -DirPlayerToCamera.z * (maxDistance - LeftHitInfoHelper.distance - WallDamping);
            }
        }

        // and for the TopHelper
        if (TopHitInfoHelper.collider != null)
        {
            if (TopHitInfoHelper.distance < maxDistance)
            {
                CameraPosCheckTop.x += -DirPlayerToCamera.x * (maxDistance - TopHitInfoHelper.distance - WallDamping);
                CameraPosCheckTop.y += -DirPlayerToCamera.y * (maxDistance - TopHitInfoHelper.distance - WallDamping);
                CameraPosCheckTop.z += -DirPlayerToCamera.z * (maxDistance - TopHitInfoHelper.distance - WallDamping);
            }
        }


        //The Distances of the 4 possible CameraPositions to the palyer
        checkDistanceBack = Vector3.Distance(CameraPosCheckBack, target.position);
        checkDistanceRight = Vector3.Distance(CameraPosCheckRight, target.position);
        checkDistanceLeft = Vector3.Distance(CameraPosCheckLeft, target.position);
        checkDistanceTop = Vector3.Distance(CameraPosCheckTop, target.position);

        //the shortest of those 4 Distances get calculates
        float shortestDistance = Mathf.Min(checkDistanceRight, checkDistanceLeft, checkDistanceBack, checkDistanceTop);

        //finally the Vector that  is closest to the palyer gets selected, that the Camera can react the fastest to Wall Collision
        if (shortestDistance == checkDistanceBack)
        {
            CameraFinalPosition = CameraPosCheckBack;
        }
        else if (shortestDistance == checkDistanceLeft)
        {
            CameraFinalPosition = CameraPosCheckLeft;
        }
        else if (shortestDistance == checkDistanceRight)
        {
            CameraFinalPosition = CameraPosCheckRight;
        }
        else if (shortestDistance == checkDistanceTop)
        {
            CameraFinalPosition = CameraPosCheckTop;
        }



        
        if (!firstPerson)
        {
            transform.position = Vector3.Lerp(transform.position, CameraFinalPosition, Time.deltaTime * Damping);
            transform.LookAt(target);
        }
        //Camera gets lpered from its current position to the CameraFinalPosition
        else
        {
            CameraFinalPosition = target.position + target.up / 2;
            transform.position = Vector3.Lerp(transform.position, CameraFinalPosition, Time.deltaTime * Damping);
        }



    }



    void Update()
    {
        if (firstPerson) lookUpDown();
        selectCameraPosition();
    }

    public void lookUpDown()
    {
        //Move Camera up and down 
        float angle2 = Input.GetAxis("Mouse Y") * rotationSpeed;
        float angle = Input.GetAxis("Mouse X") * rotationSpeed;
        transform.Rotate(-angle2, angle, 0);
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

    public bool firstPersonActive()
    {
        return firstPerson;
    }
}
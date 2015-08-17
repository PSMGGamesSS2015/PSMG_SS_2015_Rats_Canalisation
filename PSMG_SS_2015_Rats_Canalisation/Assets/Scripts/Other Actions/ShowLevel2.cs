using UnityEngine;
using System.Collections;

public class ShowLevel2 : MonoBehaviour {

    private bool isAlreadyShown = false;
    private Camera MainCamera;
    private Camera ShowLevel2Camera;
    private float lerp;
    public float duration = 2;
    private Vector3 camPos;
    private Quaternion camRot;
    private bool done1 = false;
    private bool done2 = false;
    private bool done3 = false;
    private bool done4 = false;
    private bool done5 = false;
    private bool done6 = false;
    private bool done7 = false;
    private Transform camera;
    private Transform step1, step2, step3, step4, step5, step6;

    void Awake()
    {
        ShowLevel2Camera = GameObject.Find("ShowLevel2Camera").GetComponent<Camera>();
        ShowLevel2Camera.enabled = false;
    }

    // Use this for initialization
    void Start()
    {
        MainCamera = GameObject.Find("FirstPerson").GetComponent<Camera>();
        camera = GameObject.Find("ShowLevel2Camera").GetComponent<Transform>();
        step1 = GameObject.Find("Level2CameraStep1").GetComponent<Transform>();
        step2 = GameObject.Find("Level2CameraStep2").GetComponent<Transform>();
        step3 = GameObject.Find("Level2CameraStep3").GetComponent<Transform>();
        step4 = GameObject.Find("Level2CameraStep4").GetComponent<Transform>();
        step5 = GameObject.Find("Level2CameraStep5").GetComponent<Transform>();
        step6 = GameObject.Find("Level2CameraStep6").GetComponent<Transform>();
        camPos = camera.transform.position;
        camRot = camera.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {


        if (done1)
        {
            lerp += Time.deltaTime / duration;
            camera.position = Vector3.Lerp(camPos, step1.position, lerp);
            camera.rotation = Quaternion.Lerp(camRot, step1.rotation, lerp);
            if (camera.position == step1.position)
            {
                done1 = false;
                done2 = true;
                lerp = 0;
            }
        }
        if (done2)
        {
            lerp += Time.deltaTime / duration;
            camera.position = Vector3.Lerp(step1.position, step2.position, lerp);
            camera.rotation = Quaternion.Lerp(step1.rotation, step2.rotation, lerp);
            if (camera.position == step2.position)
            {
                done2 = false;
                done3 = true;
                lerp = 0;
            }
        }
        if (done3)
        {
            lerp += Time.deltaTime / duration;
            camera.position = Vector3.Lerp(step2.position, step3.position, lerp);
            camera.rotation = Quaternion.Lerp(step2.rotation, step3.rotation, lerp);
            if (camera.position == step3.position)
            {
                done3 = false;
                done4 = true;
                lerp = 0;
            }
        }
        if (done4)
        {
            lerp += Time.deltaTime / (duration+1);
            camera.position = Vector3.Lerp(step3.position, step4.position, lerp);
            camera.rotation = Quaternion.Lerp(step3.rotation, step4.rotation, lerp);
            if (camera.position == step4.position)
            {
                done4 = false;
                done5 = true;
                lerp = 0;
            }
        }
        if (done5)
        {
            lerp += Time.deltaTime / duration;
            camera.position = Vector3.Lerp(step4.position, step5.position, lerp);
            camera.rotation = Quaternion.Lerp(step4.rotation, step5.rotation, lerp);
            if (camera.position == step5.position)
            {
                done5 = false;
                done6 = true;
                lerp = 0;
            }
        }
        if (done6)
        {
            lerp += Time.deltaTime / duration;
            camera.position = Vector3.Lerp(step5.position, step6.position, lerp);
            camera.rotation = Quaternion.Lerp(step5.rotation, step6.rotation, lerp);
            if (camera.position == step6.position)
            {
                done6 = false;
                done7 = true;
                lerp = 0;
            }
        }
        if (done7)
        {
            StartCoroutine(switchBackToMainCamera());
        }
    }

    IEnumerator switchBackToMainCamera()
    {
        done7 = false;

        yield return new WaitForSeconds(1);

        ShowLevel1.isInCameraOverview = false;
        MainCamera.enabled = true;
        ShowLevel2Camera.enabled = false;
    }


    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            if (!isAlreadyShown)
            {
                ShowLevel1.isInCameraOverview = true;
                isAlreadyShown = true;
                showLevel2();

            }
        }
    }

    private void showLevel2()
    {
        MainCamera.enabled = false;
        ShowLevel2Camera.enabled = true;
        done1 = true;
    }
}
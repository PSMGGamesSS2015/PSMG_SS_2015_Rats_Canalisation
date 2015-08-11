using UnityEngine;
using System.Collections;

public class FuseBoxCamera : MonoBehaviour {
    private bool isPlayerNear;
    public Camera ActionCamera;
    private Camera MainCamera;
    public float cameraShowDuration = 2f;



	// Use this for initialization
	void Start () {
        MainCamera = GameObject.Find("FirstPerson").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        isPlayerNear = this.GetComponent<ShowFuseBoxText>().isPlayerNear;

        if (isPlayerNear)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                switchCamera();
            }   
        }
	}

    private void switchCamera()
    {
        MainCamera.enabled = false;
        ActionCamera.enabled = true;
        StartCoroutine(switchBackToMainCamera()); 
    }

    IEnumerator switchBackToMainCamera()
    {
        yield return new WaitForSeconds(cameraShowDuration);
        MainCamera.enabled = true;
        ActionCamera.enabled = false;
    }
}

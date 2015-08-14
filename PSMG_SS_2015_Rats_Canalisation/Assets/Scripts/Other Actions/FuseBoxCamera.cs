using UnityEngine;
using System.Collections;

public class FuseBoxCamera : MonoBehaviour {
    private bool isPlayerNear;
    private bool alreadyActivated;
    public Camera ActionCamera;
    private Camera MainCamera;
    public float cameraShowDuration = 2f;


    void Awake()
    {
        ActionCamera.enabled = false;
    }

	// Use this for initialization
	void Start () {
        MainCamera = GameObject.Find("FirstPerson").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        alreadyActivated = this.GetComponent<ShowFuseBoxText>().alreadyActivated;
        isPlayerNear = this.GetComponent<ShowFuseBoxText>().isPlayerNear;
        if (alreadyActivated || !ActionCamera)
        {
            return;
        }

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

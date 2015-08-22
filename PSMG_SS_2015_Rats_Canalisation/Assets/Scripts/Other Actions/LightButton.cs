using UnityEngine;
using System.Collections;

public class LightButton : MonoBehaviour {
	public GameObject OnLight;
	public GameObject OffLight1;
	public GameObject OffLight2;
	public GameObject OffLight3;
	public GameObject OffButton1;
	public GameObject OffButton2;
	public float reactionDistance = 1f;
	private GameObject player;
	private GameObject button;
	public int showTime = 1;
	private bool isShowing = false;
    private Camera showCamera;
    private Camera mainCamera;


    void Awake()
    {
        showCamera = GameObject.Find("Level2LightShowCamera").GetComponent<Camera>();
        showCamera.enabled = false;
    }
	// Use this for initialization
	void Start () {
		button = GameObject.FindGameObjectWithTag ("PressButton");
		button.GetComponent<CanvasGroup>().alpha = 0f;
		transform.GetComponent<ParticleSystem>().enableEmission = false;
        mainCamera = GameObject.Find("FirstPerson").GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//Early out
		if (!OnLight)
			return;
		Vector3 rat = GameObject.FindGameObjectWithTag("Player").transform.position;
		float Realdistance = Vector3.Distance (transform.position, rat);
		if (Realdistance <= reactionDistance) {	
			playerIsNearButton ();
		} 
	}
	
	private void playerIsNearButton(){
		if (Input.GetKeyDown (KeyCode.E)) {
			GameObject.FindGameObjectWithTag ("fusersound").GetComponent<AudioSource> ().Play ();
			DoStuffWithButtons();
            StartCoroutine(cameraRoutine());
		}
		if(!isShowing)StartCoroutine (text ());
	}

    IEnumerator cameraRoutine()
    {
        ShowLevel1.isInCameraOverview = true;
        mainCamera.enabled = false;
        showCamera.enabled = true;
        DoStuffWithTarget(OnLight, true);
        if (OffLight1 != null) DoStuffWithTarget(OffLight1, false);
        if (OffLight2 != null) DoStuffWithTarget(OffLight2, false);
        if (OffLight3 != null) DoStuffWithTarget(OffLight3, false);
        yield return new WaitForSeconds(5f);
        ShowLevel1.isInCameraOverview = false;
        mainCamera.enabled = true;
        showCamera.enabled = false;
        
    }
	
	private void playerIsFar(){
		button.GetComponent<CanvasGroup>().alpha = 0f;
	}
	
	private void DoStuffWithButtons(){
		transform.GetComponent<ParticleSystem>().enableEmission = true ;
		if (OffButton1 != null) {
			OffButton1.transform.GetComponent<ParticleSystem> ().enableEmission = false;
		}
		if (OffButton2 != null) {
			OffButton2.transform.GetComponent<ParticleSystem> ().enableEmission = false;
		}
	}
	
	private void DoStuffWithTarget(GameObject t, bool on){
		if (on) {
			t.GetComponent<Light> ().enabled = true;
		}
		else {
			t.GetComponent<Light> ().enabled = false;
		}
	}
	
	IEnumerator text()
	{
		isShowing = true;
		button.GetComponent<CanvasGroup>().alpha = 1f;
		yield return new WaitForSeconds(showTime);
		button.GetComponent<CanvasGroup>().alpha = 0f;
		isShowing = false;
	}
}

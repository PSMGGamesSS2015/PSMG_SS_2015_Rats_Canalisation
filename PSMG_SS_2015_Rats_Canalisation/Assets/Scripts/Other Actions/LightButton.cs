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
	
	// Use this for initialization
	void Start () {
		button = GameObject.FindGameObjectWithTag ("PressButton");
		button.GetComponent<CanvasGroup>().alpha = 0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//Early out
		if (!OnLight)
			return;
		Vector3 rat = GameObject.FindGameObjectWithTag("Player").transform.position;
		float Realdistance = Vector3.Distance (transform.position, rat);
		if (Realdistance <= reactionDistance) {	
			playerIsNear ();
		} 
	}
	
	private void playerIsNear(){
		if (Input.GetKeyDown (KeyCode.E)) {
			DoStuffWithButton();
			DoStuffWithTarget(OnLight, true);
			if(OffLight1 != null)DoStuffWithTarget(OffLight1, false);
			if(OffLight2 != null)DoStuffWithTarget(OffLight2, false);
			if(OffLight3 != null)DoStuffWithTarget(OffLight3, false);
		}
		if(!isShowing)StartCoroutine (text ());
	}
	
	private void playerIsFar(){
		button.GetComponent<CanvasGroup>().alpha = 0f;
	}
	
	private void DoStuffWithButton(){
		transform.GetChild (0).GetComponent<ParticleSystem> ().loop = true;
		if (OffButton1 != null) {
			OffButton1.transform.GetChild (0).GetComponent<ParticleSystem> ().loop = false;
		}
		if (OffButton2 != null) {
			OffButton2.transform.GetChild (0).GetComponent<ParticleSystem> ().loop = false;
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

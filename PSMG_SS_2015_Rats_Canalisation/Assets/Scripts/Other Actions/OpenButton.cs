using UnityEngine;
using System.Collections;

public class OpenButton : MonoBehaviour {
	public GameObject target;
	public GameObject target2;
	public float reactionDistance = 1.5f;
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
		if (!target)
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
			DoStuffWithTarget(target);
			if(target2 != null)DoStuffWithTarget(target2);
		}
		if(!isShowing)StartCoroutine (text ());
	}
	
	private void playerIsFar(){
		button.GetComponent<CanvasGroup>().alpha = 0f;
	}

	private void DoStuffWithButton(){//Lässt Partikel verschwinden
		transform.GetChild (0).GetComponent<ParticleSystem> ().loop = false;
	}
	
	private void DoStuffWithTarget(GameObject t){
		if (t.tag == "fan") {
			t.GetComponent<Rotor> ().changeRotorActiveState (false);
		}
		else {
			t.transform.position = new Vector3(0,-150,0);
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
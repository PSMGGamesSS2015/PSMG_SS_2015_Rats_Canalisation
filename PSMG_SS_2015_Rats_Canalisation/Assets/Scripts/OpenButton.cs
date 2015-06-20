using UnityEngine;
using System.Collections;

public class OpenButton : MonoBehaviour {
	public GameObject target;
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
			DoStuffWithTarget();
		}
		if(!isShowing)StartCoroutine (text ());
	}
	
	private void playerIsFar(){
		button.GetComponent<CanvasGroup>().alpha = 0f;
	}

	private void DoStuffWithButton(){//Lässt Partikel verschwinden
		transform.GetChild (0).GetComponent<ParticleSystem> ().loop = false;
	}
	
	private void DoStuffWithTarget(){
		if (target.tag == "fan") {
			target.GetComponent<Rotor> ().changeRotorActiveState (false);
		}
		else {
			Destroy (target);
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
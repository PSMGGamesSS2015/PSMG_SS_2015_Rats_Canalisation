using UnityEngine;
using System.Collections;

public class OpenButton : MonoBehaviour {
	public GameObject target;
	public float reactionDistance = 1.0f;
	private GameObject buttonText;
	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		buttonText = GameObject.FindGameObjectWithTag ("PressButton");
		buttonText.GetComponent<CanvasGroup>().alpha = 0f;
	}

	void FixedUpdate () {
		if (Vector3.Distance (transform.position, player.transform.position) <= reactionDistance) {	
			playerIsNear ();
		} else {
			playerIsFar ();
		}
	} 

	private void DoStuffWithButton(){
		Destroy (this.gameObject);	//Zerstört Button
	}

	private void DoStuffWithTarget(){
		if (target.tag == "fan") {
			target.GetComponent<Rotor>().changeRotorActiveState(false);
		}
		else {
			Destroy (target); //Zerstört Zielobject
		}
	}

	private void playerIsNear(){
		GameObject.FindGameObjectWithTag ("PressButton").GetComponent<CanvasGroup> ().alpha = 1f;
		if (Input.GetKeyDown(KeyCode.E)){
			DoStuffWithTarget();
			DoStuffWithButton();
		}
	}

	private void playerIsFar(){
		GameObject.FindGameObjectWithTag ("PressButton").GetComponent<CanvasGroup>().alpha = 0f;
	}
}

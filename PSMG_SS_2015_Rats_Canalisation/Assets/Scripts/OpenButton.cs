using UnityEngine;
using System.Collections;

public class OpenButton : MonoBehaviour {
	public GameObject target;
	public float reactionDistance = 1f;
	private GameObject player;
	public int showTime = 3;

	// Use this for initialization
	void Start () {

	}

	void Update(){
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
			if (Vector3.Distance (transform.position, player.transform.position) <= reactionDistance) {	
				if (target != null) {
					playerIsNear ();
				}
			} else {
				playerIsFar ();
			}
	}

	private void playerIsNear(){
		GameObject.FindGameObjectWithTag ("PressButton").GetComponent<CanvasGroup>().alpha = 1f;
		if (Input.GetKeyDown (KeyCode.E)) {
			DoStuffWithButton();
			DoStuffWithTarget();
		}
	}
	
	private void playerIsFar(){
		GameObject.FindGameObjectWithTag ("PressButton").GetComponent<CanvasGroup>().alpha = 0f;
	}

	private void DoStuffWithButton(){
		//Destroy (this.gameObject);	//Zerstört Button
	}
	
	private void DoStuffWithTarget(){
		if (target.tag == "fan") {
			target.GetComponent<Rotor> ().changeRotorActiveState (false);
		}
		else {
			Destroy (target); //Zerstört Zielobject
		}
	}
}
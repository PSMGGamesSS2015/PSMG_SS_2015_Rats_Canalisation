using UnityEngine;
using System.Collections;

public class OpenButton : MonoBehaviour {
	public GameObject target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnMouseDown(){
		// this object was clicked - do something
		DoStuffWithButton ();
		if (target != null)
			DoStuffWithTarget ();
	}  

	private void DoStuffWithButton(){
		Destroy (this.gameObject);	//Zerstört Button
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

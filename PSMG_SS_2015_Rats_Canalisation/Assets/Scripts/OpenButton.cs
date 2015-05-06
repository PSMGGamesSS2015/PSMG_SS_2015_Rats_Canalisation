using UnityEngine;
using System.Collections;

public class OpenButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnMouseDown(){
		// this object was clicked - do something
		Destroy (this.gameObject);	//Zerstört Button
		Destroy (GameObject.FindGameObjectWithTag ("Gitter")); //Zerstört Gitter
	}  
}

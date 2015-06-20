using UnityEngine;
using System.Collections;

public class Rotor : MonoBehaviour {
	private bool active = true;
	private int smooth = 20;
	public int rotationSpeed = 2;


	// Use this for initialization
	void Start () {
	
	}

	//Do stuff if collision with player
	void OnCollisionEnter (Collision col) {
		if(col.gameObject == GameObject.FindGameObjectWithTag("Player"))
			GameObject.FindGameObjectWithTag("Player").GetComponent<Attributes>().Die();
	}
	
	void FixedUpdate() {
		if (active) {
			transform.Rotate (Vector3.up * smooth * rotationSpeed * Time.deltaTime);
		}
	}

	public void changeRotorActiveState(bool activeState) {
		active = activeState;
	}

}

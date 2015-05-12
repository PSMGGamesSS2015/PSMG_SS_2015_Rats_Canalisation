using UnityEngine;
using System.Collections;



public class GegnerMovement : MonoBehaviour {

	public float movementSpeed = 3f;
	public float reactionDistance = 10.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		float dist = Vector3.Distance(player.transform.position, transform.position);
		if (dist < reactionDistance) {
			Vector3 newPos = transform.forward.normalized * movementSpeed * Time.deltaTime;
			transform.position = (transform.position + newPos);
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			other.transform.position = new Vector3(0, 0, 0);
		}
		
	}
}

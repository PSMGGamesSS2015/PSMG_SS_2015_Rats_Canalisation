using UnityEngine;
using System.Collections;



public class GegnerMovement : MonoBehaviour {

	public float movementSpeed = 3f;
	public float reactionDistance = 10.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		transform.LookAt(player.transform);
		if(Vector3.Distance(transform.position,player.transform.position) <= reactionDistance){	
			transform.position += transform.forward*movementSpeed*Time.deltaTime;	
		}	
	}

	void OnTriggerEnter(Collider other){
			GameObject.FindGameObjectWithTag("Player").GetComponent<Attributes>().Die();		
	}
}

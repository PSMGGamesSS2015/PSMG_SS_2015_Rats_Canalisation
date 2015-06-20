using UnityEngine;
using System.Collections;

public class GegnerMovement : MonoBehaviour {
	
	public float movementSpeed = 3f;
	public float reactionDistance = 10.0f;
	public int damage = 5;
	private Vector3 startPos; 
	
	// Use this for initialization
	void Start () {
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		if(Vector3.Distance(transform.position,player.transform.position) <= reactionDistance){	
			playerIsNear(player);
		}	
		if (player.GetComponent<Attributes> ().diedcheck ()) {
			playerDied();
		}	
	}
	
	//Do stuff if player is near
	void playerIsNear (GameObject player){
		transform.position += transform.forward*movementSpeed*Time.deltaTime;	
		transform.LookAt(player.transform);
	}
	
	//Do stuff if collision with player
	void OnCollisionEnter (Collision col) {
		if(col.gameObject == GameObject.FindGameObjectWithTag("Player"))
			GameObject.FindGameObjectWithTag("Player").GetComponent<Attributes>().Die();
	}
	
	void playerDied(){
		transform.position = startPos;
	}
}
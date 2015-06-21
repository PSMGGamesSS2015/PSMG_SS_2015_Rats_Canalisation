using UnityEngine;
using System.Collections;

public class CheeseTrigger : MonoBehaviour {
	private Vector3 startPos; 
	
	// Use this for initialization
	void Start () {
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		if (player.GetComponent<Attributes> ().diedcheck ()) {
			playerDied();
		}	
	}
	
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			GameObject.FindGameObjectWithTag("Player").GetComponent<Attributes>().gotCheese();
			transform.position = new Vector3(0,-150,0);
		}
		
	}
	
	void playerDied(){
		transform.position = startPos;
	}
}
using UnityEngine;
using System.Collections;

public class CheeseTrigger : MonoBehaviour {
	private Vector3 startPos; 
	private int smooth = 20;
	public int rotationSpeed = 2;
	
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

	void FixedUpdate(){
		transform.Rotate (Vector3.forward * smooth * rotationSpeed * Time.deltaTime);
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
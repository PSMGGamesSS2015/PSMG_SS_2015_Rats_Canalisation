using UnityEngine;
using System.Collections;

public class PassiveEnemy : MonoBehaviour {
	public float movementSpeed = 1f;
	public float rotationSpeed = 1f;
	public float reactionDistance = 2.0f;
	public int damage = 3;
	private GameObject player;
	public GameObject lightspot1;
	public GameObject lightspot2;
	public GameObject lightspot3;

	
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance (transform.position, player.transform.position) <= reactionDistance
		    && (player.transform.position.y - transform.position.y ) <= 2) {	
			playerIsNear ();
		} else {
			goToLight (lightspot1);
			goToLight (lightspot2);
			goToLight (lightspot3);
		}
	}

	void goToLight(GameObject lightspot){
		if (lightspot != null) {
			if(lightspot.transform.GetComponent<Light> ().enabled == true
			   && Vector3.Distance (transform.position, lightspot.transform.position ) > 0.5){
				Vector3 followLight = (lightspot.transform.position - transform.position).normalized * movementSpeed * Time.deltaTime;
				followLight.y = 0.0f;
				transform.position += followLight;
				transform.LookAt(new Vector3(lightspot.transform.position.x,transform.position.y,lightspot.transform.position.z));
			}
		}
	}
	
	//Do stuff if player is near
	void playerIsNear (){
		transform.LookAt (player.transform);
		transform.position += transform.forward * movementSpeed * Time.deltaTime;
	}
	
	//Do stuff if collision with player
	void OnCollisionEnter (Collision col) {
		if(col.gameObject == GameObject.FindGameObjectWithTag("Player"))
			GameObject.FindGameObjectWithTag("Player").GetComponent<Attributes>().ChangeLife(-damage);
	}
}

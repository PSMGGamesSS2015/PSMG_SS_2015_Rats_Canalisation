using UnityEngine;
using System.Collections;

public class Rotor : MonoBehaviour {
	private bool active = true;
	private int smooth = 20;
	public int rotationSpeed = 2;
	public float smallDistance = 1f;
	public float middleDistance = 3f;
	public float bigDistance = 5f;
	
	// Use this for initialization
	void Start () {

	}
	
	//Do stuff if collision with player
	void OnCollisionEnter (Collision col) {
		if(col.gameObject == GameObject.FindGameObjectWithTag("Player"))
            GameObject.FindGameObjectWithTag("Player").GetComponent<Attributes>().ChangeLife(-(Attributes.health + 1));
	}
	
	void FixedUpdate() {
		if (active) {
			transform.Rotate (Vector3.up * smooth * rotationSpeed * Time.deltaTime);
		}
		checkHowNear ();
	}

	 void checkHowNear(){
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		Debug.Log (Vector3.Distance (transform.position, player.transform.position));
		if (Vector3.Distance (transform.position, player.transform.position) <= smallDistance) {	
			turnUpVolume (smallDistance * 0.1f);
		} else if (Vector3.Distance (transform.position, player.transform.position) <= middleDistance) {	
			turnUpVolume (middleDistance * 0.1f);
		} else if (Vector3.Distance (transform.position, player.transform.position) <= bigDistance) {
			turnUpVolume (bigDistance * 0.1f);
		} else {
			//turnUpVolume(0);
		}
	}

	void turnUpVolume (float volume){
		GameObject.FindGameObjectWithTag("rotorsound").GetComponent<AudioSource> ().volume = volume;
		/*if(!GameObject.FindGameObjectWithTag ("rotorsound").GetComponent<AudioSource> ().isPlaying)
		GameObject.FindGameObjectWithTag ("rotorsound").GetComponent<AudioSource> ().Play ();*/
	}
	
	public void changeRotorActiveState(bool activeState) {
		active = activeState;
	}
	
}
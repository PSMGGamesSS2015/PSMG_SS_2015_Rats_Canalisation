using UnityEngine;
using System.Collections;

public class Rotor : MonoBehaviour {
	private bool active = true;
	private int smooth = 20;
	public int rotationSpeed = 2;
	public float Distance = 5f;
	public float middleDistance = 3f;
	public float bigDistance = 1f;
	
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
			transform.Rotate (Vector3.up * smooth * -rotationSpeed * Time.deltaTime);
			checkHowNear ();
		}
	}

	 void checkHowNear(){
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		float distance = Vector3.Distance (transform.position, player.transform.position);
		if (distance <= Distance) {	
			turnUpVolume (Distance * 0.1f);
		}
	}

	void turnUpVolume (float volume){
		if (!GameObject.FindGameObjectWithTag ("rotorsound").GetComponent<AudioSource> ().isPlaying) {
			GameObject.FindGameObjectWithTag ("rotorsound").GetComponent<AudioSource> ().Play ();
			GameObject.FindGameObjectWithTag("rotorsound").GetComponent<AudioSource> ().volume = volume;
		}
	}

	void turnOff(){
		GameObject.FindGameObjectWithTag ("rotorsound").GetComponent<AudioSource> ().Stop ();
	}
	
	public void changeRotorActiveState(bool activeState) {
		active = activeState;
		if (activeState == false)
			turnOff ();
	}
	
}
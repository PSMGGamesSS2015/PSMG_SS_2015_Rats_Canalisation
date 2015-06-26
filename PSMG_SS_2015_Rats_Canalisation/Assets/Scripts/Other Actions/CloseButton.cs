using UnityEngine;
using System.Collections;

public class CloseButton : MonoBehaviour {
	public GameObject target;
	public float posX = 0;
	public float posY = 0;
	public float posZ = 0;
	public float reactionDistance = 1.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Update is called once per frame
	void FixedUpdate () {
		//Early out
		if (!target)
			return;
		Vector3 rat = GameObject.FindGameObjectWithTag("Player").transform.position;
		float Realdistance = Vector3.Distance (transform.position, rat);
		if (Realdistance <= reactionDistance) {	
			playerIsNear ();
		} 
	}
	
	private void playerIsNear(){
		if (Input.GetKeyDown (KeyCode.E)) {
			DoStuffWithTarget();
		}
	}

	private void DoStuffWithTarget(){
			target.transform.position = new Vector3(posX,posY,posZ);
	}
}

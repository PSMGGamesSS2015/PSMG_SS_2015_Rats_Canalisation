using UnityEngine;
using System.Collections;

public class LightFlicker : MonoBehaviour {
	public float timeOn = 0.1f;
	public float timeOff = 0.5f;
	private float changeTime = 0;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Time.time > changeTime)
		{ transform.GetComponent<Light>().enabled = !transform.GetComponent<Light>().enabled; 
			if (transform.GetComponent<Light>().enabled) {
				changeTime = Time.time + timeOn; 
			}
			else { 
				changeTime = Time.time + timeOff; 
			} 
		} 
	}
}

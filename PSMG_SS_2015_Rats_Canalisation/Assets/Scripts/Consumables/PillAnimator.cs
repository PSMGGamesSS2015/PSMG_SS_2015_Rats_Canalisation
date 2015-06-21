using UnityEngine;
using System.Collections;

public class PillAnimator : MonoBehaviour {
	private int smooth = 20;
	public int rotationSpeed = 2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.Rotate (Vector3.forward * smooth * rotationSpeed * Time.deltaTime);
	}
}

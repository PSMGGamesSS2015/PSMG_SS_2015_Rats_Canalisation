using UnityEngine;
using System.Collections;

public class GlassTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			GameObject.FindGameObjectWithTag("Player").GetComponent<Attributes>().ChangeLife(-3);
		}
		
	}
}

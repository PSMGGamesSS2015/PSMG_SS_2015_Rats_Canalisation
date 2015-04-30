using UnityEngine;
using System.Collections;

public class CheeseTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			GameObject.FindGameObjectWithTag("Hungertext").GetComponent<HungerText>().gotCheese();
			Destroy (gameObject);
		}

	}
}

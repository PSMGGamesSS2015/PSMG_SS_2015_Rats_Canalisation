using UnityEngine;
using System.Collections;

public class ButtonTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(GameObject.Find("UNITY Gatter rund 3"));
        }
    }
}

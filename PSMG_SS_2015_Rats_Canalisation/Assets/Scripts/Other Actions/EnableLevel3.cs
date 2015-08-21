using UnityEngine;
using System.Collections;

public class EnableLevel3 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            MainMenuLevelSelection.canLevel3 = true;
        }
    }
}

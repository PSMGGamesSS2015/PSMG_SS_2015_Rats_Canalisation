using UnityEngine;
using System.Collections;

public class PrepareLevel2 : MonoBehaviour {

    public GameObject gateUp;
    public GameObject gateDown;

	// Use this for initialization
	void Awake () {
        if (MainMenuLevelSelection.level2Startet)
        {
            Vector3 oldPos1 = gateUp.GetComponent<Transform>().position;
            oldPos1.y += 2;
            gateUp.GetComponent<Transform>().position = oldPos1;
            Vector3 oldPos2 = gateDown.GetComponent<Transform>().position;
            oldPos2.y -= 2;
            gateDown.GetComponent<Transform>().position = oldPos2;

        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

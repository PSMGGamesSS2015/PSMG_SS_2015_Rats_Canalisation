using UnityEngine;
using System.Collections;

public class DisableRotor : MonoBehaviour {

    public GameObject rotor;
    private bool alreadyActivated;
    private Vector3 rotPos;
    private bool isPlayerNear;

	// Use this for initialization
	void Start () {
        rotPos = rotor.transform.eulerAngles;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        isPlayerNear = this.GetComponent<ShowFuseBoxText>().isPlayerNear;
        alreadyActivated = this.GetComponent<ShowFuseBoxText>().alreadyActivated;
        if (!rotor || alreadyActivated)
        {
            return;
        }
        if (isPlayerNear)
        {
            playerIsNear();
        }
	}

    private void playerIsNear()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (rotor != null)
            {
                disableRotor();
            }
        }
    }

    private void disableRotor()
    {
        rotor.GetComponent<Rotor>().changeRotorActiveState(false);
        rotor.transform.eulerAngles = rotPos;
    }
}

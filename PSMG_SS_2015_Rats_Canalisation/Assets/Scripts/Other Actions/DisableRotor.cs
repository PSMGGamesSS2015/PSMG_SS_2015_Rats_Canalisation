using UnityEngine;
using System.Collections;

public class DisableRotor : MonoBehaviour {

    public GameObject rotor;
    private GameObject rat;
    private float reactionDistance;
    private bool alreadyActivated;
    private Vector3 rotPos;

	// Use this for initialization
	void Start () {
        reactionDistance = this.GetComponent<ShowFuseBoxText>().reactionDistance;
        rat = GameObject.FindGameObjectWithTag("Player");
        rotPos = rotor.transform.eulerAngles;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        alreadyActivated = this.GetComponent<ShowFuseBoxText>().alreadyActivated;
        if (!rotor || alreadyActivated)
        {
            return;
        }
        Vector3 ratPos = rat.transform.position;
        float realdistance = Vector3.Distance(transform.position, ratPos);
        if (realdistance <= reactionDistance)
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

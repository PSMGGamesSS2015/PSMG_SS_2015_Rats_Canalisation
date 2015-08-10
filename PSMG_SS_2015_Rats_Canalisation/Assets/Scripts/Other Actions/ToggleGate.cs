using UnityEngine;
using System.Collections;

public class ToggleGate : MonoBehaviour {

    public GameObject gate;
    private GameObject rat;
    private float reactionDistance;
    private bool alreadyActivated;
    public bool wantToClose;
    private Vector3 gatePos;
    private bool animate = false;
    private Vector3 newGatePos;
    private float lerp;
    public float gateToggleSlowness = 2;

	// Use this for initialization
	void Start () {
        reactionDistance = this.GetComponent<ShowFuseBoxText>().reactionDistance;
        rat = GameObject.FindGameObjectWithTag("Player");

	}

    void FixedUpdate()
    {
        alreadyActivated = this.GetComponent<ShowFuseBoxText>().alreadyActivated;
        if (!gate || alreadyActivated)
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

    void Update()
    {
        if (animate)
        {
            lerp += Time.deltaTime/ gateToggleSlowness;
            gate.transform.position = Vector3.Lerp(gatePos, newGatePos, lerp);

            if (gate.transform.position == newGatePos)
            {
                animate = false;
            }
        }
    }

    private void playerIsNear()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (gate != null)
            {
                toggleGate();
            }
        }
    }

    private void toggleGate()
    {
        animate = false;
        gatePos = gate.transform.position;
        newGatePos = gatePos;
        if (wantToClose)
        {        
            newGatePos.y -= 2f;
            animate = true;
            wantToClose = false;
        }
        else { 
            newGatePos.y += 2f;
            animate = true;
            wantToClose = true;
        }
       

    }
}

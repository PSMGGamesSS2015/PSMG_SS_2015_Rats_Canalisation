using UnityEngine;
using System.Collections;

public class ToggleGate : MonoBehaviour {

    public GameObject gate;
    private bool alreadyActivated=false;
    public bool wantToClose;
    private Vector3 gatePos;
    private bool animate = false;
    private Vector3 newGatePos;
    private float lerp;
    public float gateToggleSlowness = 2;
    private bool isPlayerNear;

	// Use this for initialization
	void Start () {

	}

    void FixedUpdate()
    {
        isPlayerNear = this.GetComponent<ShowFuseBoxText>().isPlayerNear;
        
        if (!gate || alreadyActivated)
        {
            return;
        }
        alreadyActivated = this.GetComponent<ShowFuseBoxText>().alreadyActivated;
        if (isPlayerNear)
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
        }
        else { 
            newGatePos.y += 2f;
            animate = true;
        }
       

    }
}

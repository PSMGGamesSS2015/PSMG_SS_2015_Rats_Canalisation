using UnityEngine;
using System.Collections;

public class PillTrigger : MonoBehaviour {
	private Vector3 startPos;

    public delegate void PillAction();
    public static event PillAction OnPillConsumed;
	
	// Use this for initialization
	void Start () {
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {	
	}

    void OnEnable()
    {
        RatManager.OnDie += RespawnPill;
    }

    void DisAble()
    {
        RatManager.OnDie -= RespawnPill;
    }
	
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			GameObject.FindGameObjectWithTag("Timer").GetComponent<Timer>().setDefaults();
            OnPillConsumed();
			transform.position = new Vector3(0,-150,0);
		}
		
	}
	
	void RespawnPill(){
		transform.position = startPos;
	}
}
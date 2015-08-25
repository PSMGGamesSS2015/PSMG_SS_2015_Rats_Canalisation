using UnityEngine;
using System.Collections;

public class GegnerMovement : MonoBehaviour {
	
	public float movementSpeed = 1.5f;
	public float reactionDistance = 10.0f;
	public int damage = 3;
	private Vector3 startPos; 
	
	// Use this for initialization
	void Start () {
		startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		if(Vector3.Distance(transform.position,player.transform.position) <= reactionDistance){	
			playerIsNear(player);
		}	
	}

    void Enable()
    {
        RatManager.OnDie += RespawnEnemy;
    }

    void Disable()
    {
        RatManager.OnDie -= RespawnEnemy;
    }
	
	//Do stuff if player is near
	void playerIsNear (GameObject player){
		Vector3 followLight = (player.transform.position - transform.position).normalized * movementSpeed * Time.deltaTime;
		followLight.y = 0.0f;
		transform.position += followLight;
		transform.LookAt(new Vector3(player.transform.position.x,transform.position.y,player.transform.position.z));
	}
	
	//Do stuff if collision with player
	void OnCollisionEnter (Collision col) {
		if(col.gameObject == GameObject.FindGameObjectWithTag("Player"))
			GameObject.FindGameObjectWithTag("Player").GetComponent<Attributes>().ChangeLife(-damage);
	}

    void RespawnEnemy()
    {
		transform.position = startPos;
	}
}
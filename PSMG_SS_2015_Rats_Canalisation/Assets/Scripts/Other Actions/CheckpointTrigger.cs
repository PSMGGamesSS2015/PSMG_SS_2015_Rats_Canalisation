using UnityEngine;
using System.Collections;

public class CheckpointTrigger : MonoBehaviour {

    //Position the Player respawns
    public static Vector3 SpawnpointPosition;
    //final Direction the Player looks at when respawning;
    public static Transform finalDirection;
    //Empty Object that carries the position to respawm at
    public Transform Spawnpoint;
    //Empty Object the Player looks at when respawning
    public Transform Direction;


    public delegate void CheckPointReached();
    public static event CheckPointReached OnCheckPointReached;
 

	// Use this for initialization
	void Start () {
        SpawnpointPosition = GameObject.Find("Spawnpoint Main Area").GetComponent<Transform>().position;
        finalDirection = GameObject.Find("Direction Main Area").GetComponent<Transform>();
		GameObject.FindGameObjectWithTag ("Checkpoint").GetComponent<CanvasGroup>().alpha = 0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            OnCheckPointReached();
            SpawnpointPosition = Spawnpoint.position;
            finalDirection = Direction;
        }
    }

    public Vector3 getSpawnpointPosition()
    {
        return SpawnpointPosition;
    }

    public Transform getDirection()
    {
        return finalDirection;
    }
}

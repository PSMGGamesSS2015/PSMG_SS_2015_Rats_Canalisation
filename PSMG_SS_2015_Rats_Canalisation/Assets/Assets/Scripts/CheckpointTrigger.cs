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

	public float waitingCheckpointText = 1;
 

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
			if(! GameObject.FindGameObjectWithTag("Player").GetComponent<Attributes>().diedcheck())StartCoroutine( text() );
            SpawnpointPosition = Spawnpoint.position;
            finalDirection = Direction;
        }
    }

	private void showText(){
		Vector3 onScreen = new Vector3 (Screen.width/8, 250, 0);
		Vector3 offScreen = new Vector3 (Screen.width/8, 1000, 0);
		GameObject.FindGameObjectWithTag ("Checkpoint").GetComponent<RectTransform>().localPosition = onScreen;
		wait ();
		GameObject.FindGameObjectWithTag ("Checkpoint").GetComponent<RectTransform>().localPosition = offScreen;
	}

	IEnumerator text()
	{
		GameObject.FindGameObjectWithTag ("Checkpoint").GetComponent<CanvasGroup>().alpha = 1f;
		yield return new WaitForSeconds(waitingCheckpointText);
		GameObject.FindGameObjectWithTag ("Checkpoint").GetComponent<CanvasGroup>().alpha = 0f;
	}

	private void wait(){

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

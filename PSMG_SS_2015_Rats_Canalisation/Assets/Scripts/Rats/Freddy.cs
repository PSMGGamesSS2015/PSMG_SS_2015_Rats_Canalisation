using UnityEngine;
using System.Collections;

public class Freddy : MonoBehaviour {
	public float FreddyReaction = 1f;
	private bool isShowing = false;
	private bool keyHasBeenPressed = false;
	public int showTime = 1;
	public int boxTime = 3;
	private GameObject talk;
	private GameObject talkBox;
	private GameObject talkText;

	// Use this for initialization
	void Start () {
		talk = GameObject.FindGameObjectWithTag("FreddyTalk");
		talk.GetComponent<CanvasGroup>().alpha = 0f;
		talkBox = GameObject.FindGameObjectWithTag("Talkbox");
		talkBox.GetComponent<CanvasGroup>().alpha = 0f;
		talkText = GameObject.FindGameObjectWithTag("Talktext");
		talkText.GetComponent<CanvasGroup>().alpha = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		if(Vector3.Distance(transform.position,player.transform.position) <= FreddyReaction){	
			playerIsNear();
		}

	}

	private void playerIsNear(){
		if (Input.GetKeyDown (KeyCode.E)) {
			keyHasBeenPressed = true;
			talk.GetComponent<CanvasGroup>().alpha = 0f;
			StartCoroutine (box ());
		}
		if(!isShowing && !keyHasBeenPressed)StartCoroutine (text ());
	}

	IEnumerator text()
	{
		isShowing = true;
		talk.GetComponent<CanvasGroup>().alpha = 1f;
		yield return new WaitForSeconds(showTime);
		talk.GetComponent<CanvasGroup>().alpha = 0f;
		isShowing = false;
	}

	IEnumerator box()
	{
		isShowing = true;
		talkBox.GetComponent<CanvasGroup>().alpha = 1f;
		talkText.GetComponent<CanvasGroup>().alpha = 1f;
		yield return new WaitForSeconds(boxTime);
		talkBox.GetComponent<CanvasGroup>().alpha = 0f;
		talkText.GetComponent<CanvasGroup>().alpha = 0f;
		isShowing = false;
	}
}

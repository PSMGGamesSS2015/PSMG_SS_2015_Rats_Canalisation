using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Freddy : MonoBehaviour {
	public float FreddyReaction = 1f;
	public string FreddysText = "";
	private bool isShowing = false;
	private bool keyHasBeenPressed = false;
	private int showTime = 1;
	private int boxTime = 3;
	private GameObject talk;
	private GameObject talkBox;
	private GameObject talkText;
	private int counter = 30;

	// Use this for initialization
	void Start () {
		talk = GameObject.FindGameObjectWithTag("FreddyTalk");
		talk.GetComponent<CanvasGroup>().alpha = 0f;
		talkBox = GameObject.FindGameObjectWithTag("Talkbox");
		talkBox.GetComponent<CanvasGroup>().alpha = 0f;
		talkText = GameObject.FindGameObjectWithTag("Talktext");
		talkText.GetComponent<CanvasGroup>().alpha = 0f;
		Text freddystext = talkText.GetComponent<Text> ();
		freddystext.text = FreddysText;
	}
	
	// Update is called once per frame
	void Update () {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		if(Vector3.Distance(transform.position,player.transform.position) <= FreddyReaction){	
			playerIsNear();
		}

	}

	private void moveRightLeft(){
		if (counter > 0) {
			transform.Rotate (Vector3.up *10 * Time.deltaTime);
			counter--;
		} else if (counter > -30) {
			transform.Rotate (-Vector3.up * 10 * Time.deltaTime);
			counter--;
		} else {
			counter+=60;
		}
	}

	private void playerIsNear(){
		if (Input.GetKeyDown (KeyCode.E)) {
			keyHasBeenPressed = true;
			talk.GetComponent<CanvasGroup>().alpha = 0f;
			StartCoroutine (box ());
		}
		moveRightLeft ();
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

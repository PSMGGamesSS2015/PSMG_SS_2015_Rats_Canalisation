using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Timer : MonoBehaviour {
	private float counter = 1f;
	private float pasttime = 0;

	// Use this for initialization
	void Start () {
		transform.GetComponent<CanvasGroup>().alpha = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (GameObject.FindGameObjectWithTag ("Player").GetComponent<RatMovement>().checkRageMode()) {
			timerProcess ();
		}
	}

	private void timerProcess(){
		pasttime += Time.deltaTime;
		transform.GetComponent<CanvasGroup>().alpha = 1f;
		String mytext = transform.GetComponent<Text> ().text;
		double dtens = Char.GetNumericValue(mytext[2]);
		double dsingles = Char.GetNumericValue (mytext [3]);
		int tens = Convert.ToInt32(dtens);
		int singles = Convert.ToInt32(dsingles);
		if (pasttime > counter){
			pasttime -= counter;
			if(singles>0){
				singles--;
			}
			else if(tens>0){
				tens--;
				singles+=9;
			}
			else{
				transform.GetComponent<CanvasGroup>().alpha = 0f;
				GameObject.FindGameObjectWithTag("Player").GetComponent<RatMovement>().deactivateRagemode();
			}
			mytext = "0:"+tens+singles;
			transform.GetComponent<Text> ().text = mytext;
		}
	}
}

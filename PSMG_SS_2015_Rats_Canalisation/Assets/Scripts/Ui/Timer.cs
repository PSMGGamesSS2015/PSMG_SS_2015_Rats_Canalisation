using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Timer : MonoBehaviour {
	private float counter = 1f;
	private float pasttime = 0;
	public static int defaultTens = 3;
	public static int defaultSingles = 0;
	private int tens = defaultTens;
	private int singles = defaultSingles;

    public delegate void DeactivateRageMode();
    public static event DeactivateRageMode OnDeactivateRageMode;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (RatManager.isRageMode) {
			timerProcess ();
		} else {
			transform.GetComponent<CanvasGroup>().alpha = 0f;
		}
	}

	private void timerProcess(){
		pasttime += Time.deltaTime;
		transform.GetComponent<CanvasGroup>().alpha = 1f;
		String mytext = transform.GetComponent<Text> ().text;
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
				tens = defaultTens;
				singles = defaultSingles;
				transform.GetComponent<CanvasGroup>().alpha = 0f;
                OnDeactivateRageMode();
			}
			mytext = "0:"+tens+singles;
			transform.GetComponent<Text> ().text = mytext;
		}
	}
}

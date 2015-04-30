using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HungerText : MonoBehaviour {
	public Text instruction;
	public char instructionChar;
	public float pastTime;
	public int hungerCounter;
	public int timeToDropHungerOneValue = 10; //in seconds


	// Use this for initialization
	void Start () {
		instruction = GetComponent<Text>();
		instructionChar = instruction.text[8];
		hungerCounter = (int)instructionChar - '0';
		setNewText ();
	}
	
	// Update is called once per frame
	void Update () {

		pastTime += Time.deltaTime;
		if (pastTime > timeToDropHungerOneValue) {
			if(hungerCounter > 0){
				hungerCounter--;
				GameObject player = GameObject.FindGameObjectWithTag("Player");
				player.GetComponent<Attributes>().ChangeHunger(-1);

			}
			pastTime -= timeToDropHungerOneValue;
			setNewText ();
		}
	}

	public void setNewText(){
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		int currentHunger = player.GetComponent<Attributes>().GetCurrentHunger();
		instruction.text = instruction.text.Substring (0, 7) + currentHunger;
	}

	public void gotCheese(){
		hungerCounter++;
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		player.GetComponent<Attributes>().ChangeHunger(1);
		setNewText ();
	}
}

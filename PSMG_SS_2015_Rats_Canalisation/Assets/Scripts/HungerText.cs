using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HungerText : MonoBehaviour {
	public Text instruction;
	public char instructionChar;
	public float pastTime;
	public int hungerCounter;
	public int timeToDropHungerOneValue = 10;

	// Use this for initialization
	void Start () {
		instruction = GetComponent<Text>();
		instructionChar = instruction.text[8];
		hungerCounter = (int)instructionChar - '0';
		Debug.Log (hungerCounter);
	}
	
	// Update is called once per frame
	void Update () {
		pastTime += Time.deltaTime;
		if (pastTime > timeToDropHungerOneValue) {
			if(hungerCounter > 0){
				hungerCounter--;}
			pastTime -= timeToDropHungerOneValue;
			setNewText ();
		}
	}

	public void setNewText(){
		instruction.text = instruction.text.Substring (0, 7) + hungerCounter;
	}

	public void gotCheese(){
		hungerCounter++;
		setNewText ();
	}
}

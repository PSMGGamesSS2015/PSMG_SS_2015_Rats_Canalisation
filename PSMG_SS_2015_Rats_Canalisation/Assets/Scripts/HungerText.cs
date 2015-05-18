using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HungerText : MonoBehaviour {
	public Text instruction;
	public char instructionChar;
	public float pastTime;
	public int hungerCounter;
	
	// Use this for initialization
	void Start () {
		instruction = GetComponent<Text>();
		instructionChar = instruction.text[8];
		hungerCounter = (int)instructionChar - '0';
		setNewText ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void setNewText(){
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		int currentHunger = player.GetComponent<Attributes>().GetCurrentHunger();
		instruction.text = instruction.text.Substring (0, 7) + currentHunger;
	}


}

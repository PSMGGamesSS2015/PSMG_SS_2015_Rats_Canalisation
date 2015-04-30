using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LebenText : MonoBehaviour {
	public Text instruction;
	public char instructionChar;
	public float pastTime;
	public int lifeCounter;
	public int timeToDropHungerOneValue = 10; //in seconds
	
	
	// Use this for initialization
	void Start () {
		instruction = GetComponent<Text>();
		instructionChar = instruction.text[8];
		lifeCounter = (int)instructionChar - '0';
		setNewText ();
	}
	
	// Update is called once per frame
	void Update () {
	}
	
	public void setNewText(){
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		int currentHunger = player.GetComponent<Attributes>().GetCurrentLife();
		instruction.text = instruction.text.Substring (0, 7) + currentHunger;
	}
	
	public void updateLife(){
		setNewText ();
	}
}

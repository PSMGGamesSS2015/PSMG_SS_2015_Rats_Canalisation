using UnityEngine;
using System.Collections;

public class Attributes : MonoBehaviour {
	public int maxHealth = 7;
	public int maxHunger = 7;
	private int health;
	private int hunger;

	// Use this for initialization
	void Start () {
		health = maxHealth;
		hunger = maxHunger;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ChangeHunger (int value){
		hunger += value;
		if (hunger > maxHunger)
			hunger = maxHunger;
	}

	public int GetCurrentHunger(){
		return hunger;
	}
}

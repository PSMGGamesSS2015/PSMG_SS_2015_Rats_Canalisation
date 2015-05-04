using UnityEngine;
using System.Collections;

public class Attributes : MonoBehaviour {
	public int maxHealth = 7;
	public int maxHunger = 7;
	private int health;
	private int hunger;
	private float pastTime = 0;
	public int timeToHeal = 5; //in seconds

	// Use this for initialization
	void Start () {
		health = maxHealth;
		hunger = maxHunger;
	}
	
	// Update is called once per frame
	void Update () {
		pastTime += Time.deltaTime;
		if (pastTime > timeToHeal) {//Heal
			int Healnumber = 1;
			if( hunger == maxHunger){
				Healnumber = 2;
			}
			ChangeLife(Healnumber);
			pastTime -= timeToHeal;
		}
	}

	public void ChangeHunger (int value){
		hunger += value;
		if (hunger > maxHunger)
			hunger = maxHunger;
	}

	public void ChangeLife (int value){
		health += value;
		if (health > maxHealth)
			health = maxHealth;
		GameObject.FindGameObjectWithTag ("Lifetext").GetComponent<LebenText>().setNewText(health);
	}

	public int GetCurrentHunger(){
		return hunger;
	}

	public int GetCurrentLife(){
		return health;
	}

}

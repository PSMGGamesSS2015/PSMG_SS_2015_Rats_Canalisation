using UnityEngine;
using System.Collections;

public class Attributes : MonoBehaviour {
	public int maxHealth = 10;
	public int maxHunger = 5;
	private int health;
	private int hunger;
	private float pastTime = 0;
	public int timeToHeal = 10; //in seconds
	private static int normalHealing = 1;
	private static int betterHealing = 2;
	public int timeToDropHungerOneValue = 10; //in seconds
	private float pastHungerTime = 0;
	public int looseLifeWhileHungry = 2;

	// Use this for initialization
	void Start () {
		health = maxHealth;
		hunger = maxHunger;
	}
	
	// Update is called once per frame
	void Update () {
		pastTime += Time.deltaTime;
		pastHungerTime += Time.deltaTime;

		if (pastTime > timeToHeal) {//Heal from time to time
			AutomaticalLifeHeal();
		}
		if (health <= 0) {//If the player dies
			Die();

		}
		if (pastHungerTime > timeToDropHungerOneValue ) {//Drop Hunger
			if(hunger > 0){
			AutomaticalHungerDrop();
			}
			else {
				ChangeLife (-looseLifeWhileHungry);
				pastHungerTime -= timeToDropHungerOneValue;
			}
		}
	}

	private void AutomaticalHungerDrop(){
		if(hunger > 0){
			hunger--;
		}
		pastHungerTime -= timeToDropHungerOneValue;
		GameObject.FindGameObjectWithTag("Hungertext").GetComponent<HungerText>().setNewText ();
	}

	private void AutomaticalLifeHeal(){
		int Healnumber = normalHealing;
		if( hunger == maxHunger){
			Healnumber = betterHealing;
		}
		ChangeLife(Healnumber);
		pastTime -= timeToHeal;
	}

	public void Die(){
		health =  maxHealth;
		hunger = maxHunger;
		GameObject.FindGameObjectWithTag("Hungertext").GetComponent<HungerText>().setNewText ();
		GameObject.FindGameObjectWithTag("Lifetext").GetComponent<LebenText>().setNewText();
		Vector3 newPos = new Vector3(0, 0, 0);
		//this.transform.position = newPos;
        this.transform.position = GameObject.FindGameObjectWithTag("Respawn").GetComponent<CheckpointTrigger>().getSpawnpointPosition();
        this.transform.LookAt(GameObject.FindGameObjectWithTag("Respawn").GetComponent<CheckpointTrigger>().getDirection());
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
		GameObject.FindGameObjectWithTag ("Lifetext").GetComponent<LebenText>().setNewText();
	}

	public int GetCurrentHunger(){
		return hunger;
	}

	public int GetCurrentLife(){
		return health;
	}

	public void gotCheese(){
		if (hunger > maxHunger){
			hunger++;
		}
		ChangeHunger(1);
		GameObject.FindGameObjectWithTag ("Hungertext").GetComponent<HungerText>().setNewText();
	}

}

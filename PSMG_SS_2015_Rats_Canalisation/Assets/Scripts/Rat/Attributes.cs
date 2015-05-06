using UnityEngine;
using System.Collections;

public class Attributes : MonoBehaviour {
	public int maxHealth = 7;
	public int maxHunger = 7;
	private int health;
	private int hunger;
	private float pastTime = 0;
	public int timeToHeal = 5; //in seconds
	private static int normalHealing = 1;
	private static int betterHealing = 2;

	// Use this for initialization
	void Start () {
		health = maxHealth;
		hunger = maxHunger;
	}
	
	// Update is called once per frame
	void Update () {
		pastTime += Time.deltaTime;
		if (pastTime > timeToHeal) {//Heal from time to time
			int Healnumber = normalHealing;
			if( hunger == maxHunger){
				Healnumber = betterHealing;
			}
			ChangeLife(Healnumber);
			pastTime -= timeToHeal;
		}
		if (health <= 0) {//If the player dies
			health =  maxHealth;
			hunger = maxHunger;
			Vector3 newPos = new Vector3(0, 0, 0);
			this.transform.position = newPos;
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

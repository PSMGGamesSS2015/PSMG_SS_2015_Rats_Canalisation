using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
	public float waitingInfoText = 1f;
	public float waitingDamage = 0.25f;
	private bool justDied = false;
	
	// Use this for initialization
	void Start () {
		GameObject.FindGameObjectWithTag ("Damage").GetComponent<CanvasGroup>().alpha = 0f;
		GameObject.FindGameObjectWithTag ("Lost").GetComponent<CanvasGroup>().alpha = 0f;
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
		if (!GameObject.FindGameObjectWithTag ("Player").GetComponent<RatMovement> ().checkGodMode()) {
			health = maxHealth;
			hunger = maxHunger;
			StartCoroutine (text ());   
			this.transform.position = GameObject.FindGameObjectWithTag ("Respawn").GetComponent<CheckpointTrigger> ().getSpawnpointPosition ();
			this.transform.LookAt (GameObject.FindGameObjectWithTag ("Respawn").GetComponent<CheckpointTrigger> ().getDirection ());
		}
	}
	
	public void goToLastCheckpoint()
	{
		this.transform.position = GameObject.FindGameObjectWithTag("Respawn").GetComponent<CheckpointTrigger>().getSpawnpointPosition();
		this.transform.LookAt(GameObject.FindGameObjectWithTag("Respawn").GetComponent<CheckpointTrigger>().getDirection());
	}
	
	IEnumerator text()
	{
		GameObject.FindGameObjectWithTag ("Lost").GetComponent<CanvasGroup>().alpha = 1f;
		justDied = true;
		yield return new WaitForSeconds(waitingInfoText);
		GameObject.FindGameObjectWithTag ("Lost").GetComponent<CanvasGroup>().alpha = 0f;
		justDied = false;
	}
	
	public void ChangeHunger (int value){
		hunger += value;
		if (hunger > maxHunger)
			hunger = maxHunger;
	}
	
	public void ChangeLife (int value){
		if (value < 0 && !justDied)
			StartCoroutine (damageScreen ());
		health += value;
		if (health > maxHealth)
			health = maxHealth;
	}
	
	IEnumerator damageScreen()
	{
		GameObject.FindGameObjectWithTag ("damagesound").GetComponent<AudioSource>().Play();
		GameObject.FindGameObjectWithTag ("Damage").GetComponent<CanvasGroup>().alpha = 0.5f;
		yield return new WaitForSeconds(waitingDamage);
		GameObject.FindGameObjectWithTag ("Damage").GetComponent<CanvasGroup>().alpha = 0f;
		
	}
	
	public bool diedcheck(){
		return justDied;
	}
	
	
	public int GetCurrentHunger(){
		return hunger;
	}
	
	public int GetCurrentLife(){
		return health;
	}
	
	public void gotCheese(){
		GameObject.FindGameObjectWithTag ("cheesesound").GetComponent<AudioSource>().Play();
		if (hunger > maxHunger){
			hunger++;
		}
		ChangeHunger(1);
	}
	
}
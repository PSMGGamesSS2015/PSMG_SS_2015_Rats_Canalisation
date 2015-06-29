using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Attributes : MonoBehaviour {
	public int maxHealth = 10;
	public int maxHunger = 5;
	public static int health;
	public static int hunger;
	private float pastTime = 0;
	public int timeToHeal = 10; //in seconds
	private static int normalHealing = 1;
	private static int betterHealing = 2;
	public int timeToDropHungerOneValue = 10; //in seconds
	private float pastHungerTime = 0;
	public int looseLifeWhileHungry = 2;
	

    public delegate void DamageAction();
    public static event DamageAction OnDamageGotten;
	
	// Use this for initialization
	void Start () {
        setFullStats();
		
	}
	
	// Update is called once per frame
	void Update () {
		pastTime += Time.deltaTime;
		pastHungerTime += Time.deltaTime;
		
		if (pastTime > timeToHeal) {//Heal from time to time
			AutomaticalLifeHeal();
		}
		if (pastHungerTime > timeToDropHungerOneValue ) {//Drop Hunger
			bool modeActive = RatManager.isRageMode || RatManager.isGodMode;
			if(hunger > 0 && !modeActive){
				AutomaticalHungerDrop();
			}
			else {
				ChangeLife (-looseLifeWhileHungry);
				pastHungerTime -= timeToDropHungerOneValue;
			}
		}
	}

    void OnEnable()
    {
        RatManager.OnDie += setFullStats;
    }

    void OnDisable()
    {
        RatManager.OnDie -= setFullStats;
    }

    public void setFullStats()
    {
        health = maxHealth;
        hunger = maxHunger;
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

	
	
	
	
	public void ChangeHunger (int value){
		hunger += value;
		if (hunger > maxHunger)
			hunger = maxHunger;
	}
	
	public void ChangeLife (int value){
		if (value + health > maxHealth)
        {
            health = maxHealth;
        } else{
            health += value;
            OnDamageGotten();
        }
			
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
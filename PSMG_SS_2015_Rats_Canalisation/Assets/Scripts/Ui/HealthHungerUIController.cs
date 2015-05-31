using UnityEngine;
using System.Collections;

public class HealthHungerUIController : MonoBehaviour {


    //heart variables
    private int currentHealth;
    private int pastHealth;
    private bool isHealthChanged = false;
    private bool[] HeartBoolArray = new bool[10];

    //cheese variables
    private int currentHunger;
    private int pastHunger;
    private bool isHungerChanged = false;
    private bool[] CheeseBoolArray = new bool[5];

    //heart event
    public delegate void HealthChangeAction(bool[] boolArray);
    public static event HealthChangeAction OnHealthChanged;

    //cheese event
    public delegate void HungerChangeAction(bool[] boolArray);
    public static event HungerChangeAction OnHungerChanged;

	// Use this for initialization
	void Start () {
        //get start variables for hearts
        getCurrentHealth();
        pastHealth = currentHealth;

        //get start variables for hunger
        getCurrentHunger();
        pastHunger = currentHunger;
	}
	
	// Update is called once per frame
	void Update () {

        //health
        getCurrentHealth();
        checkIfHealthChanged();
        if (isHealthChanged)
        {
            InitOnHealthChanged();
        }

        //hunger
        getCurrentHunger();
        checkIfHungerChanged();
        if (isHungerChanged)
        {
            InitOnHungerChanged();
        }
	}

    //checks if Health has changed
    private void checkIfHealthChanged()
    {
        if (currentHealth != pastHealth)
        {
            isHealthChanged = true;
        }
        else
        {
            isHealthChanged = false;
        }
        pastHealth = currentHealth;
    }

    //checks if Hunger has changed
    private void checkIfHungerChanged()
    {
        if (currentHunger != pastHunger)
        {
            isHungerChanged = true;
        }
        else
        {
            isHungerChanged = false;
        }
        pastHunger = currentHunger;
    }

    //get current HP
    private void getCurrentHealth()
    {
        currentHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Attributes>().GetCurrentLife();
    }

    //get current Hunger
    private void getCurrentHunger()
    {
        currentHunger = GameObject.FindGameObjectWithTag("Player").GetComponent<Attributes>().GetCurrentHunger();
    }

    private void InitOnHealthChanged()
    {

        for (int i = 0; i < currentHealth; i++)
        {
            HeartBoolArray[i] = true;
        }
        for (int j = currentHealth; j < 10; j++)
        {
            HeartBoolArray[j] = false;
        }

         
        OnHealthChanged(HeartBoolArray);
    }

    private void InitOnHungerChanged()
    {
        for (int i = 0; i < currentHunger; i++)
        {
            CheeseBoolArray[i] = true;
        }
        for (int j = currentHunger; j < 5; j++)
        {
            CheeseBoolArray[j] = false;
        }

        OnHungerChanged(CheeseBoolArray);
    }
}

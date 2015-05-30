using UnityEngine;
using System.Collections;

public class HealthUIController : MonoBehaviour {

    private int currentHealth = 10;
    private int pastHealth = 10;
    private bool isHealthChanged = false;
    private bool heart1IsFull, heart2IsFull, heart3IsFull, heart4IsFull, heart5IsFull, heart6IsFull, heart7IsFull, heart8IsFull, heart9IsFull, heart10IsFull;
    private bool[] HeartBoolArray = new bool[10];

    public delegate void HealthChangeAction(bool[] boolArray);
    public static event HealthChangeAction OnHealthChanged; 

	// Use this for initialization
	void Start () {
	    heart1IsFull = true;
        heart2IsFull = true;
        heart3IsFull = true;
        heart4IsFull = true;
        heart5IsFull = true;
        heart6IsFull = true;
        heart7IsFull = true;
        heart8IsFull = true;
        heart9IsFull = true;
        heart10IsFull = true;
	}
	
	// Update is called once per frame
	void Update () {
        getCurrentHealth();
        checkIfHealthChanged();
        if (isHealthChanged)
        {
            InitOnHealthChanged();
        }
	}

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

    private void getCurrentHealth()
    {
        currentHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Attributes>().GetCurrentLife();
    }

    private void InitOnHealthChanged()
    {
        switch (currentHealth)
        {
            case 10:
                heart1IsFull = true;
                heart2IsFull = true;
                heart3IsFull = true;
                heart4IsFull = true;
                heart5IsFull = true;
                heart6IsFull = true;
                heart7IsFull = true;
                heart8IsFull = true;
                heart9IsFull = true;
                heart10IsFull = true;
                break;
            case 9:
                heart1IsFull = true;
                heart2IsFull = true;
                heart3IsFull = true;
                heart4IsFull = true;
                heart5IsFull = true;
                heart6IsFull = true;
                heart7IsFull = true;
                heart8IsFull = true;
                heart9IsFull = true;
                heart10IsFull = false;
                break;
            case 8:
                heart1IsFull = true;
                heart2IsFull = true;
                heart3IsFull = true;
                heart4IsFull = true;
                heart5IsFull = true;
                heart6IsFull = true;
                heart7IsFull = true;
                heart8IsFull = true;
                heart9IsFull = false;
                heart10IsFull = false;
                break;
            case 7:
                heart1IsFull = true;
                heart2IsFull = true;
                heart3IsFull = true;
                heart4IsFull = true;
                heart5IsFull = true;
                heart6IsFull = true;
                heart7IsFull = true;
                heart8IsFull = false;
                heart9IsFull = false;
                heart10IsFull = false;
                break;
            case 6:
                heart1IsFull = true;
                heart2IsFull = true;
                heart3IsFull = true;
                heart4IsFull = true;
                heart5IsFull = true;
                heart6IsFull = true;
                heart7IsFull = false;
                heart8IsFull = false;
                heart9IsFull = false;
                heart10IsFull = false;
                break;
            case 5:
                heart1IsFull = true;
                heart2IsFull = true;
                heart3IsFull = true;
                heart4IsFull = true;
                heart5IsFull = true;
                heart6IsFull = false;
                heart7IsFull = false;
                heart8IsFull = false;
                heart9IsFull = false;
                heart10IsFull = false;
                break;
            case 4:
                heart1IsFull = true;
                heart2IsFull = true;
                heart3IsFull = true;
                heart4IsFull = true;
                heart5IsFull = false;
                heart6IsFull = false;
                heart7IsFull = false;
                heart8IsFull = false;
                heart9IsFull = false;
                heart10IsFull = false;
                break;
            case 3:
                heart1IsFull = true;
                heart2IsFull = true;
                heart3IsFull = true;
                heart4IsFull = false;
                heart5IsFull = false;
                heart6IsFull = false;
                heart7IsFull = false;
                heart8IsFull = false;
                heart9IsFull = false;
                heart10IsFull = false;
                break;
            case 2:
                heart1IsFull = true;
                heart2IsFull = true;
                heart3IsFull = false;
                heart4IsFull = false;
                heart5IsFull = false;
                heart6IsFull = false;
                heart7IsFull = false;
                heart8IsFull = false;
                heart9IsFull = false;
                heart10IsFull = false;
                break;
            case 1:
                heart1IsFull = true;
                heart2IsFull = false;
                heart3IsFull = false;
                heart4IsFull = false;
                heart5IsFull = false;
                heart6IsFull = false;
                heart7IsFull = false;
                heart8IsFull = false;
                heart9IsFull = false;
                heart10IsFull = false;
                break;
            case 0:
                heart1IsFull = false;
                heart2IsFull = false;
                heart3IsFull = false;
                heart4IsFull = false;
                heart5IsFull = false;
                heart6IsFull = false;
                heart7IsFull = false;
                heart8IsFull = false;
                heart9IsFull = false;
                heart10IsFull = false;
                break;
            default:
                heart1IsFull = false;
                heart2IsFull = false;
                heart3IsFull = false;
                heart4IsFull = false;
                heart5IsFull = false;
                heart6IsFull = false;
                heart7IsFull = false;
                heart8IsFull = false;
                heart9IsFull = false;
                heart10IsFull = false;
                break;      
        }
        HeartBoolArray[0] = heart1IsFull;
        HeartBoolArray[1] = heart2IsFull;
        HeartBoolArray[2] = heart3IsFull;
        HeartBoolArray[3] = heart4IsFull;
        HeartBoolArray[4] = heart5IsFull;
        HeartBoolArray[5] = heart6IsFull;
        HeartBoolArray[6] = heart7IsFull;
        HeartBoolArray[7] = heart8IsFull;
        HeartBoolArray[8] = heart9IsFull;
        HeartBoolArray[9] = heart10IsFull;

        OnHealthChanged(HeartBoolArray);
    }
}

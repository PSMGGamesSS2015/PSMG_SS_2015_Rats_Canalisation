using UnityEngine;
using System.Collections;

public class GlassTrigger : MonoBehaviour
{

    //true when player is standing in the glass
    private bool isInGlass = false;
    //initial Damage when entering Glass area
    public int initalDamage = 3;
    //damage applied while standing in Glass area each damageIntervall
    public int damagePerDamageIntervall = 1;
    //timeintervall damage is applied in seconds
    public int damageIntervall = 1;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }



    //applies inital damage and sets Variable isInGlass to true
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isInGlass = true;
            GameObject.FindGameObjectWithTag("Player").GetComponent<Attributes>().ChangeLife(-initalDamage);
        }
        initRepeatingDamage();
    }

    //initsCoRoroutine for doing damage
    void initRepeatingDamage()
    {
        StartCoroutine(doDamage());
    }

    //applies damage each damageIntervall
    IEnumerator doDamage()
    {
        yield return new WaitForSeconds(damageIntervall);
        if (isInGlass)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Attributes>().ChangeLife(-damagePerDamageIntervall);
            initRepeatingDamage();
        }
    }

    // sets Variable isInGlass to false
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isInGlass = false;
        }
    }
}

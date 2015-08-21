using UnityEngine;
using System.Collections;

public class PrepareLevel3 : MonoBehaviour {

    public GameObject gate1;
    public GameObject gate2;
    public GameObject gate3;
    public GameObject gate4;

    // Use this for initialization
    void Awake()
    {
        if (MainMenuLevelSelection.level3Startet)
        {
            
            Vector3 oldPos2 = gate2.GetComponent<Transform>().position;
            oldPos2.y -= 2;
            gate2.GetComponent<Transform>().position = oldPos2;
            Vector3 oldPos1 = gate4.GetComponent<Transform>().position;
            oldPos1.y += 2;
            gate4.GetComponent<Transform>().position = oldPos1;

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
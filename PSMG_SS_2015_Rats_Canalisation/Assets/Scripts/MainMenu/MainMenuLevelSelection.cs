using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuLevelSelection : MonoBehaviour {

    private Button level1, level2, level3;
    public static bool canLevel1 = true;
    public static bool canLevel2 = false;
    public static bool canLevel3 = false;
    public static bool level2Startet = false;
    public static bool level3Startet = false;


    void Awake()
    {
        
    }

	// Use this for initialization
	void Start () {

        level1 = GameObject.Find("Level1").GetComponent<Button>();
        level2 = GameObject.Find("Level2").GetComponent<Button>();
        level3 = GameObject.Find("Level3").GetComponent<Button>();

        
        level2.interactable = false;
        level3.interactable = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (canLevel1)
        {
            level1.interactable = true;
        }
        if (canLevel2)
        {
            level2.interactable = true;
        }
        if (canLevel3)
        {
            level3.interactable = true;
        }
	}

    public void startLevel2()
    {
        level2Startet = true;
    }

    public void startLevel3()
    {
        level3Startet = true;
    }

}

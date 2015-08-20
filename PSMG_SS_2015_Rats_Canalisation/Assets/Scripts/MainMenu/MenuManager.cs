using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

    public MainMenu CurrentMenu;

	// Use this for initialization
	void Start () {
        ShowMenu(CurrentMenu);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ShowMenu(MainMenu menu)
    {
        if (CurrentMenu != null)
            CurrentMenu.isOpen = false;

        CurrentMenu = menu;
        CurrentMenu.isOpen = true;

    }
}

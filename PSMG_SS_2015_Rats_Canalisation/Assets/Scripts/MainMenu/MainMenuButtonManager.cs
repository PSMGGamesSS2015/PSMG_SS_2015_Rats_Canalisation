using UnityEngine;
using System.Collections;

public class MainMenuButtonManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void CloseApplication()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        Application.LoadLevel(1);
    }
}

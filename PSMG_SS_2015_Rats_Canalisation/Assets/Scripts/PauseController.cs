using UnityEngine;
using System.Collections;

public class PauseController : MonoBehaviour {

    public static bool isPaused = false;

    public delegate void PauseAction();
    public static event PauseAction OnPauseChanged;

	// Use this for initialization
	void Start () {
        Cursor.visible = false; 
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            togglePause();
        }
	}

    public void togglePause()
    {
        if (isPaused)
        {
            isPaused = false;
            Cursor.visible = false;
            Time.timeScale = 1;
            OnPauseChanged();
        }
        else
        {
            isPaused = true;
            Cursor.visible = true;
            OnPauseChanged();
            Time.timeScale = 0;
            
        }
    }
}

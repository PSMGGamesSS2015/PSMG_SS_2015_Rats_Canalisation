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
            OnPauseChanged();
            StartCoroutine(UnPauseWithDelay()); 
        }
        else
        {
            isPaused = true;
            Cursor.visible = true;
            OnPauseChanged();
            Time.timeScale = 0;
            
        }
    }

    IEnumerator UnPauseWithDelay()
    {
        yield return StartCoroutine(CoroutineUtil.WaitForRealSeconds(1.5f));
        Time.timeScale = 1;
    }

    public void exitApp()
    {
        Application.Quit();
    }

    public void GoToMainMenu()
    {
        isPaused = false;
        Application.LoadLevel(0);
    }

    public void resetTimeScale()
    {
        Time.timeScale = 1;
    }
}

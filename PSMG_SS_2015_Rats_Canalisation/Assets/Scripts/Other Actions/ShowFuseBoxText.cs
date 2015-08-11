using UnityEngine;
using System.Collections;

public class ShowFuseBoxText : MonoBehaviour {
    private GameObject rat;
    private GameObject button;
    public float reactionDistance = 1.5f;
    public int showTime = 1;
    private bool isShowing = false;
    public bool alreadyActivated = false;
    public bool isPlayerNear = false;

	// Use this for initialization
	void Start () 
    {
        rat = GameObject.FindGameObjectWithTag("Player");
        button = GameObject.FindGameObjectWithTag("PressButton");
        button.GetComponent<CanvasGroup>().alpha = 0f;
	}

    void FixedUpdate()
    {
        // Early out
        if (alreadyActivated)
        {
            return;
        }

        Vector3 ratPos = rat.transform.position;
        float realdistance = Vector3.Distance (transform.position, ratPos);
        if (realdistance <= reactionDistance)
        {
            isPlayerNear = true;
            playerIsNear();
        }
        else isPlayerNear = false;
    }

    private void playerIsNear()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            DoStuffWithButton();
        }
        if (!isShowing) StartCoroutine(showText());
    }

    private void playerIsFar()
    {
        button.GetComponent<CanvasGroup>().alpha = 0f;
    }

    private void DoStuffWithButton()
    {
        //Lässt Partikel verschwinden
        transform.GetChild(0).GetComponent<ParticleSystem>().loop = false;
        alreadyActivated = true;
    }

    IEnumerator showText()
    {
        isShowing = true;
        button.GetComponent<CanvasGroup>().alpha = 1f;
        yield return new WaitForSeconds(showTime);
        button.GetComponent<CanvasGroup>().alpha = 0f;
        isShowing = false;
    }
}

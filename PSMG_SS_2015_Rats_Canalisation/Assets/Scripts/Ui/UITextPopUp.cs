using UnityEngine;
using System.Collections;

public class UITextPopUp : MonoBehaviour {

    public float waitingInfoText = 1f;
    public float waitingDamage = 0.25f;
    public float waitingCheckpointText = 1f;
    private bool justDied = false;

	// Use this for initialization
	void Start () {
        GameObject.FindGameObjectWithTag("Damage").GetComponent<CanvasGroup>().alpha = 0f;
        GameObject.FindGameObjectWithTag("Lost").GetComponent<CanvasGroup>().alpha = 0f;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnEnable()
    {
        RatManager.OnDie += DieUIProcedure;
        Attributes.OnDamageGotten += DamageUIProcedure;
        CheckpointTrigger.OnCheckPointReached += CheckPointTextProcedure;
    }

    void OnDisable()
    {
        RatManager.OnDie -= DieUIProcedure;
        Attributes.OnDamageGotten -= DamageUIProcedure;
        CheckpointTrigger.OnCheckPointReached -= CheckPointTextProcedure;
    }

    private void CheckPointTextProcedure()
    {
        if (!justDied)
        {
            StartCoroutine(ShowCheckPointText());
        }
    }

    IEnumerator ShowCheckPointText()
    {
        GameObject.FindGameObjectWithTag("Checkpoint").GetComponent<CanvasGroup>().alpha = 1f;
        yield return new WaitForSeconds(waitingCheckpointText);
        GameObject.FindGameObjectWithTag("Checkpoint").GetComponent<CanvasGroup>().alpha = 0f;
    }

    private void DamageUIProcedure()
    {
        bool modeActive = RatManager.isGodMode || RatManager.isRageMode;
        if (!justDied && !modeActive)
            StartCoroutine(ShowDamageScreen());
    }

    IEnumerator ShowDamageScreen()
    {
        GameObject.FindGameObjectWithTag("damagesound").GetComponent<AudioSource>().Play();
        GameObject.FindGameObjectWithTag("Damage").GetComponent<CanvasGroup>().alpha = 0.5f;
        yield return new WaitForSeconds(waitingDamage);
        GameObject.FindGameObjectWithTag("Damage").GetComponent<CanvasGroup>().alpha = 0f;

    }

    private void DieUIProcedure()
    {
        StartCoroutine(DieText());   
        GameObject.FindGameObjectWithTag("Timer").GetComponent<CanvasGroup>().alpha = 0f;
    }

    IEnumerator DieText()
    {
        GameObject.FindGameObjectWithTag("Lost").GetComponent<CanvasGroup>().alpha = 1f;
        justDied = true;
        yield return new WaitForSeconds(waitingInfoText);
        GameObject.FindGameObjectWithTag("Lost").GetComponent<CanvasGroup>().alpha = 0f;
        justDied = false;
    }
}

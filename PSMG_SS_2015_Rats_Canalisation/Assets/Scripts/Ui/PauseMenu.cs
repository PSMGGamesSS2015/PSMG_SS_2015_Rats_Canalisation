using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour
{

    private Animator anim;
    public float RohrID;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnEnable()
    {
        PauseController.OnPauseChanged += StartCoroutineForAnimation;
    }

    void OnDisable()
    {
        PauseController.OnPauseChanged -= StartCoroutineForAnimation;
    }

    void StartCoroutineForAnimation()
    {
        StartCoroutine(Animation());
    }

    IEnumerator Animation()
    {
        yield return StartCoroutine(CoroutineUtil.WaitForRealSeconds(RohrID*0.2f));
        anim.SetBool("isPaused", PauseController.isPaused);
    }

}

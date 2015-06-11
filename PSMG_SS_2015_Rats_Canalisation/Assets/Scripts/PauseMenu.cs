using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour
{

    private Animator anim;

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
        PauseController.OnPauseChanged += Animate;
    }

    void OnDisable()
    {
        PauseController.OnPauseChanged -= Animate;
    }

    void Animate()
    {
        anim.SetBool("isPaused", PauseController.isPaused);
    }

}

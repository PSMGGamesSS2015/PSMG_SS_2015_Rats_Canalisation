using UnityEngine;
using System.Collections;

public class RatAnimationController : MonoBehaviour {

    private Animator anim;
    private bool isWalking = false;
    private bool isJumping = false;
    private bool isRunning = false;
    private bool isDead = false;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (isJumping != RatManager.isJumping)
        {
            anim.SetBool("isJumping", RatManager.isJumping);
            isJumping = RatManager.isJumping;
        }
        if (isWalking != RatManager.isWalking)
        {
            anim.SetBool("isWalking", RatManager.isWalking);
            isWalking = RatManager.isWalking;
        }

        if (isRunning != RatManager.isRunning)
        {
            anim.SetBool("isRunning", RatManager.isRunning);
            isRunning = RatManager.isRunning;
        }

        if (isDead != RatManager.isDead)
        {
            anim.SetBool("isDead", RatManager.isDead);
            isDead = RatManager.isDead;
        }
     

        
        

	}
}

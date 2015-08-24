using UnityEngine;
using System.Collections;

public class RatManager : MonoBehaviour {

    public static bool isRageMode = false;
    public static bool isGodMode = false;
    public static bool isWalking = false;
    public static bool isRunning = false;
    public static bool isJumping = false;
    public static bool isDead = false;

    public delegate void GodModeToggle();
    public static event GodModeToggle OnGodModeToggle;

    public delegate void DieAction();
    public static event DieAction OnDie;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        extremeHeal();
        checkIfDead();
        GodModeActivate();
	}

    void OnEnable()
    {
        PillTrigger.OnPillConsumed += RageModeActivate;
        Timer.OnDeactivateRageMode += RageModeDeactivate;
    }

    void OnDisable()
    {
        PillTrigger.OnPillConsumed -= RageModeActivate;
        Timer.OnDeactivateRageMode -= RageModeActivate;
    }

    private void RageModeActivate()
    {
        isRageMode = true;
        isGodMode = false;
        transform.GetComponent<ParticleSystem>().enableEmission = true;

    }

    public void RageModeDeactivate()
    {
        isRageMode = false;
        transform.GetComponent<ParticleSystem>().enableEmission = false;
    }

    private void GodModeActivate()
    {
        if (Input.GetKeyDown(KeyCode.L) && !PauseController.isPaused)
        {
            if (isGodMode)
            {
                isGodMode = false;
                OnGodModeToggle();
            }
            else
            {
                isGodMode = true;
                OnGodModeToggle();
            }
        }

    }

    private void checkIfDead()
    {
        if ((Attributes.health <= 0 && !isGodMode) || transform.position.y < -10)
        {
            if (!isDead)
            {
                OnDie();
                isRageMode = false;
                isDead = true;
                transform.GetComponent<ParticleSystem>().enableEmission = false;
                StartCoroutine(RespawnWithDelay());
            }
        }
    }

    IEnumerator RespawnWithDelay()
    {
        yield return new WaitForSeconds(3);
        isDead = false;
        GoToLastCheckPoint();
    }

    public void GoToLastCheckPoint()
    {
        this.transform.position = GameObject.FindGameObjectWithTag("Respawn").GetComponent<CheckpointTrigger>().getSpawnpointPosition();
        this.transform.LookAt(GameObject.FindGameObjectWithTag("Respawn").GetComponent<CheckpointTrigger>().getDirection());
    }



    private void extremeHeal()
    {
        if (isGodMode || isRageMode)
        {
            transform.GetComponent<Attributes>().ChangeLife(5);
        }
        
    }
}

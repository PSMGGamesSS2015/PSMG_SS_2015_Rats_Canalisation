using UnityEngine;
using System.Collections;

public class CheeseAnim : MonoBehaviour
{

    private Animator anim;
    public int cheeseID = 0;
    public bool isFull = true;

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
        HealthHungerUIController.OnHungerChanged += Animate;
    }

    void OnDisable()
    {
        HealthHungerUIController.OnHungerChanged -= Animate;
    }

    void Animate(bool[] cheeseBoolArray)
    {
        isFull = cheeseBoolArray[cheeseID - 1];
        anim.SetBool("isFull", isFull);
    }
}

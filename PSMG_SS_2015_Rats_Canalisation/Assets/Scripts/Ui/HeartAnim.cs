using UnityEngine;
using System.Collections;

public class HeartAnim : MonoBehaviour
{

    private Animator anim;
    public int heartID = 0;
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
        HealthUIController.OnHealthChanged += Animate;
    }

    void OnDisable()
    {
        HealthUIController.OnHealthChanged -= Animate;
    }

    void Animate(bool[] heartBoolArray)
    {
        isFull = heartBoolArray[heartID - 1];
        Debug.Log("isFull: "+isFull);
        anim.SetBool("isFull", isFull);
    }
}

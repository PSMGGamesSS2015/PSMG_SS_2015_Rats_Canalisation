using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CheeseTrigger : MonoBehaviour {
	private Vector3 startPos; 
	private int smooth = 20;
	public int rotationSpeed = 2;

    [SerializeField]
    private Button MyButton = null; 

    void Start()
    {
        startPos = transform.position;

        MyButton = GameObject.Find("zum letzten Checkpoint").GetComponent<Button>();
        MyButton.onClick.AddListener(() => {
            RespawnCheese();
        });
    }
	
	// Update is called once per frame
	void Update () {

	}

    void OnEnable(){
        RatManager.OnDie += RespawnCheese;
    }

    void DisAble()
    {
        RatManager.OnDie -= RespawnCheese;
    }

	void FixedUpdate(){
		transform.Rotate (Vector3.forward * smooth * rotationSpeed * Time.deltaTime);
	}
	
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			GameObject.FindGameObjectWithTag("Player").GetComponent<Attributes>().gotCheese();
			transform.position = new Vector3(0,-150,0);
		}
		
	}
	
	public void RespawnCheese(){
		transform.position = startPos;
	}
}
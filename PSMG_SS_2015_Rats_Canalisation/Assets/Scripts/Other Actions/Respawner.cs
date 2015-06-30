using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Respawner : MonoBehaviour {

	private Vector3 startPos; 
	private Vector3 rotPos;
	
	[SerializeField]
	private Button MyButton = null; 
	
	void Start(){
		startPos = transform.position;
		rotPos = transform.eulerAngles;
		
		MyButton = GameObject.Find("zum letzten Checkpoint").GetComponent<Button>();
		MyButton.onClick.AddListener(() => {
			RespawnThis();
		});
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnEnable(){
		RatManager.OnDie += RespawnThis;
	}
	
	void DisAble()
	{
		RatManager.OnDie -= RespawnThis;
	}
	
	public void RespawnThis(){
		transform.position = startPos;
		transform.eulerAngles = rotPos;
	}
}

using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    private Animator _animator;
    private CanvasGroup _canvasgroup;


    public bool isOpen
    {
        get { return _animator.GetBool("IsOpen"); }
        set { _animator.SetBool("IsOpen", value);}
    }
	// Use this for initialization
	void Awake () {
        _animator = GetComponent<Animator>();
        _canvasgroup = GetComponent <CanvasGroup>();

        var rect = GetComponent<RectTransform>();
        rect.offsetMax = rect.offsetMin = new Vector2(0, 0);
	}
	
	// Update is called once per frame
	void Update () {
        if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Open"))
        {
            _canvasgroup.blocksRaycasts = _canvasgroup.interactable = false;
        }
        else
        {
            _canvasgroup.blocksRaycasts = _canvasgroup.interactable = true;
        }
	}
}

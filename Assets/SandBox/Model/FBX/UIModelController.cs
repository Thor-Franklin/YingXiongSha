using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIModelController : MonoBehaviour ,IPointerDownHandler{

    private int userClickTimes = 0;
    [SerializeField]
    private  Animator _animator;
	// Use this for initialization
	void Start () {
        //_animator = GetComponent<Animator>();
        int id = 1;
        var go = Resources.Load<GameObject>("Prefabs/UIModel_" + id.ToString());
        //Debug.LogFormat("The go's Length is {0}", go.name);
        
        if (go!=null) { Debug.Log("Meet the Condition! "); }

    }



    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Pointer down !");
        userClickTimes += 1;
        if (userClickTimes == 1)
        {
            _animator.SetTrigger("Touch");         
        }     
        else if (userClickTimes == 2)
            _animator.SetTrigger("Greet");
        else if (userClickTimes ==3)
        {
            _animator.SetTrigger("TurnAround"); 
        }
        else if (userClickTimes ==4)
        {
            _animator.SetTrigger("Death");
        }
        else if (userClickTimes ==5)
        {
            _animator.SetTrigger("Happy");
        }
        else
        {
            _animator.SetTrigger("Jump");
            userClickTimes = 0;
        }
    }
}

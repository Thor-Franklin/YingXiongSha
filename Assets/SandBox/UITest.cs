using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DataBind.Core.Presentation;

public class UITest : MonoBehaviour,IPointerDownHandler {

    private readonly TeContext _teContext = new TeContext();

    public TeContext TeContext
    {
        get
        {
            //_teContext.tActive = true;
            return _teContext;
        }
    }
    [Header("Yamaidie")]
    [SerializeField]
    private GameObject ggg;
    public NoInherd noInherd;

    // Use this for initialization
    void Start () {
        GetComponentInParent <ContextHolder>().Context = TeContext;
        //StartCoroutine(VV());
        
        TeContext.Colorer = Color.black;
        noInherd = new NoInherd();
        _teContext.tActive = true;

        Timer ti = Timer.CreateTimer();
        ti.StartTiming(8, completed);
    }
	
	// Update is called once per frame
	void Update () {
       
	}

    public void OnPointerDown(PointerEventData eventData)
    {
       
        print("Yamadie!");
        _teContext.TxtContext = "ppppppp";
        //_teContext.tActive = false;
        print("Current state:"+TeContext.BoolGetter);
     
        Debug.Log("Current Card Count is" + TeContext.CacheCardsList.Count);
    }
    IEnumerator VV()
    {
        yield return new WaitForSeconds(3);
        Debug.Log(_teContext.tActive);
        
        Debug.Log(_teContext.TxtContext);
        yield return new WaitForSeconds(3);
        
        Debug.Log("The Child Count is " + GetComponentsInChildren<RectTransform>().Length );
        
    }

    void completed()
    {
        Debug.Log("Timer : time over !");
    }

    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    ((IPointerDownHandler)btn).OnPointerDown(eventData);
    //}
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class CardTweenPosition : MonoBehaviour {
    RectTransform rectTransf;
    Toggle t;
    Tweener tweener;
    DOTweenAnimation dta;
    public static readonly GameObjListType gameObj = new GameObjListType(cacheCards);
    private static List<GameObject> cacheCards = new List<GameObject>();

    // Use this for initialization
    void Start () {
        rectTransf = GetComponent<RectTransform>();
        t = GetComponent<Toggle>();
        t.isOn = false;
        t.onValueChanged.AddListener(OnValueChange);
        tweener = rectTransf.DOAnchorPosY(-55, 0.3f).SetAutoKill(false).Pause().SetEase(Ease.Linear);
        
    }
	
    
    void OnValueChange(bool b)
    {
        if (b)
        {
           tweener.PlayForward();          
        }
        else
        {
            tweener.PlayBackwards();
        }
    }
    
}

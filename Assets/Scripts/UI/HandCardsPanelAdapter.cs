using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandCardsPanelAdapter : MonoBehaviour {
    private float defaultWeight = 645;
    private float maxCardCount = 8;
    private float cardSpace = 5;
    private int handCardCount = 5;
    private int maxCardCountInDefaultWeight = 17;
    private float posY = -70;
    private RectTransform rectTf;
    

	// Use this for initialization
	void Start () {
        rectTf = GetComponent<RectTransform>();
        SetCardPosition();      
	}
	
    private void SetCardPosition()
    {     
        for (int i = 0; i < transform.childCount ; i++)
        {
            transform.GetChild(i).GetComponent<RectTransform>().anchoredPosition = CalculateCardPosition(i+1);
        }
        SetPanelWidth();
    }

    private Vector2 CalculateCardPosition(int index)
    {
        handCardCount = transform.childCount;
        float posX;
        if (handCardCount < 8)
        { 
            posX = ( 40 + 40+ cardSpace) * index - 45;
            Vector2 v2 = new Vector2(posX, posY);
            return v2;
        }
        else if( handCardCount == 8)
        {
            posX = (40 + 40 + 0.8f ) * index -40;
            Vector2 v2 = new Vector2(posX, posY);
            return v2;
        }
        else if (handCardCount <= 17)
        {
            posX = ((index * 645) / handCardCount-((645/handCardCount)-40));
            Vector2 v2 = new Vector2(posX, posY);
            return v2;
        }
        else
        {
            posX = index * (645-40) / maxCardCountInDefaultWeight + 5;
            Vector2 v2 = new Vector2(posX, posY);
            return v2;
        }
    }

    private void SetPanelWidth()
    {
        if (handCardCount > 17)
        {
            rectTf.sizeDelta = new Vector2((handCardCount - 17) * 38+645, rectTf.sizeDelta.y);
        }
    }
}

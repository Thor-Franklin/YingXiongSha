using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardInfo : MonoBehaviour {
    public Card card;
	// Use this for initialization
	void Start () {
       // print(card.cardName);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void DetermineCardType()
    {
        if (card != null)
        {
            if (card.cardType == CardType.BasicCard)
            {
                BasicCard bc = (BasicCard)card;
            }
            else if (card.cardType == CardType.Equipment)
            {
                EquipmentCard ec = (EquipmentCard)card;
            }
            else { StratagemCard sc = (StratagemCard)card; }
        }
    }
}

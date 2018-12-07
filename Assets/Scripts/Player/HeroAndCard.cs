using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroAndCard : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        //ClickGetTarget(abstractHero.heroData.canPlayCardNum.Value, abstractHero.heroData.CacheCards, "Card", "Card");  //select card and put them in cacheCards list
        //ClickGetTarget(abstractHero.heroData.targetNumber.Value, abstractHero.heroData.CacheTargetPlayer, "Player", "Player");  //select target player and put them in cacheTargetPlayer list
    }



    private void ClickGetTarget(int targetNumber, GameObjListType results, string compareTag, string layerMask)
    {
        if (Input.GetMouseButtonDown(0))
        {
            Collider2D col = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition), LayerMask.GetMask(layerMask));
            if (col == null)
            {
                Debug.Log("Click nothing!");
                return;
            }
            if (col.CompareTag(compareTag))
            {
                Debug.Log(col.GetComponent<CardInfo>().card.cardSkillType.ToString() + col.GetComponent<CardInfo>().card.suits.ToString() + col.GetComponent<CardInfo>().card.cardIndex.ToString());
                Debug.LogFormat("Hit the {0}", compareTag);
                if (results.Value.Count < targetNumber)
                {
                    if (!results.Value.Contains(col.gameObject))
                    {
                        results.Add(col.gameObject);
                    }
                    else
                    {
                        results.Remove(col.gameObject);// Second click the same player will be removed 
                    }
                }
                else
                {
                    results.Remove(results.Value[results.Value.Count - 1]); //if the selected gameobject count over the targetNumber, remove the last selected gameobject,and add the new one
                    results.Add(col.gameObject);
                }
            }
            //should be clear the list.
            Debug.LogFormat("Current target quantity is :{0}", results.Value.Count);
        }
    }
}

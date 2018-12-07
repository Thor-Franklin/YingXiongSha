using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataBind.Core.Data;
   

public class PlayCardContext : Context {

    private readonly Property<bool> playCardProperty = new Property<bool>();
    public bool PlayCard
    {
        get { return playCardProperty.Value; }
        set { playCardProperty.Value = value; }
    }

    private readonly Property<int> heroHpProperty = new Property<int>();
    public int HeroHP
    {
        get { return heroHpProperty.Value; }
        set { heroHpProperty.Value = value; }
    }

    private readonly Property<List<GameObject>> cacheCardsProperty = new Property<List<GameObject>>();
    public List<GameObject> CacheCardsList
    {
        get { return cacheCardsProperty.Value; }
    }

    public GameObject CacheCards
    {
        get
        {
            if (cacheCardsProperty.Value.Count != 0)
                return cacheCardsProperty.Value[0];
            else return null;
        }
        set
        {
            if (cacheCardsProperty.Value.Contains(value) && !value.GetComponent<UnityEngine.UI.Toggle>().isOn)
            {
                cacheCardsProperty.Value.Remove(value);
                Debug.Log("Remove it !");
            }
            else
            {
                cacheCardsProperty.Value.Add(value);
                Debug.Log("Add it !");
            }
        }
    }

    public void HeroSkillButtonClick()
    {

    }

    public void OKButtonClick()
    {
        //PlayCard = true;
        Debug.Log(PlayCard);

        //出牌并清空cacheCards
    }

    public void CancelButtonClick()
    {
        //弃牌
    }
}

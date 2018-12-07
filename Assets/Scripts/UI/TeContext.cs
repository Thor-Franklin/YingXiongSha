using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataBind.Core.Data;

public class TeContext : Context {
    public TeContext()
    {
        cacheCardsProperty.Value = new List<GameObject>();
        cacheTargetPlayerProperty.Value = new List<GameObject>();
    }
    private readonly Property<bool> tActiveProperty = new Property<bool>();
    public bool tActive
    {
        get { return tActiveProperty.Value; }
        set { tActiveProperty.Value = value; }
    }


    private readonly Property<bool> t2BoolProperty = new Property<bool>();
    public bool T2Bool
    {
        get { return t2BoolProperty.Value; }
        set { t2BoolProperty.Value = value; }
    }

    private readonly Property<string> txtContextProperty = new Property<string>();
    public string TxtContext
    {
        get { return txtContextProperty.Value; }
        set { txtContextProperty.Value = value; }
    }

    private readonly Property<Color> colorerProperty = new Property<Color>();
    public Color Colorer
    {
        get { return colorerProperty.Value; }
        set { colorerProperty.Value = value; }
    }

    private readonly Property<bool> boolGetterProperty = new Property<bool>();
    public bool BoolGetter
    {
        get { return boolGetterProperty.Value; }
        set { boolGetterProperty.Value = value; }
    }

    #region CacheCards And Cache Target Hero

    private readonly Property<List<GameObject>> cacheCardsProperty = new Property<List<GameObject>>();
    public List<GameObject> CacheCardsList
    {
        get { return cacheCardsProperty.Value; }
    }

    private readonly Property<List<GameObject>> cacheTargetPlayerProperty = new Property<List<GameObject>>();
    public List<GameObject> CacheTargetPlayerList
    {
        get { return cacheTargetPlayerProperty.Value; }
    }

    public GameObject CacheCards
    {
        private get { return null; }
        set
        {
            if (value.transform.CompareTag("Player"))
            {
                if (cacheTargetPlayerProperty.Value.Contains(value) && !value.GetComponent<UnityEngine.UI.Toggle>().isOn)
                {
                    {
                        cacheTargetPlayerProperty.Value.Remove(value);
                        Debug.Log("Remove Player !");
                    }
                }
                else
                {
                    cacheTargetPlayerProperty.Value.Add(value);
                    Debug.Log("Add Player !");        
                }               
            }
            else
            {
                if (cacheCardsProperty.Value.Contains(value) && !value.GetComponent<UnityEngine.UI.Toggle>().isOn)
                {
                    cacheCardsProperty.Value.Remove(value);
                    Debug.Log("Remove Card !");
                }
                else
                {
                    cacheCardsProperty.Value.Add(value);
                    Debug.Log("Add Card !");
                }
            }
         } 
    }
    #endregion

    private readonly Property<List<GameObject>> judgeCardsListProperty = new Property<List<GameObject>>();
    public List<GameObject> JudgeCardsList
    {
        get { return judgeCardsListProperty.Value; }
    }

    public GameObject JudgeCards
    {
        set
        {
            //TeContext t = new TeContext();
            //HeroData hd = new HeroData("jj", 4);
            //hd.JudgeCards.Set(t.JudgeCardsList);
            //hd.JudgeCards.Add(new GameObject());
            if (judgeCardsListProperty.Value.Contains(value))
                judgeCardsListProperty.Value.Remove(value);
            else 
            judgeCardsListProperty.Value.Add(value);
        }
    }


    private readonly Property<List<GameObject>> equipCardsListPeoperty = new Property<List<GameObject>>();
    public List<GameObject> EquipCardsList
    {
        get { return equipCardsListPeoperty.Value; }
    }

    public GameObject EquipCards
    {
        set
        {

        }
    }



    public void TogOn ()
    {
        tActive = true;
        T2Bool = false;
        TxtContext = "I miss";
        if(cacheCardsProperty.Value[0]) 
        Debug.Log(cacheCardsProperty.Value[0]);
        Debug.Log("TogOn");
    }

    public void TogOff()
    {
        Colorer = new Color(Random.Range(0.1f, 1f), Random.Range(0.1f, 1f), Random.Range(0.1f, 1f));
        Debug.Log("TogOff");
    }
}

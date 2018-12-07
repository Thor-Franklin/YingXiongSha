using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour {
    public GameObject cardPrefab; //牌的预设体
    public List<Card> deckInfo=new List<Card> ();//整副牌的信息
    public List<GameObject> deck = new List<GameObject>();//整副牌
    private string[] allCardName; //整副牌的名称
    //Card card;
    public Text text;

    private void Awake()
    {
        allCardName = GetCardNames();
        Shuffle(allCardName);
        //GenerateDeck();
        //GeneratCard();
        StartCoroutine(DisplayCard());
    }
    // Use this for initialization
 
	void Start () {
        Card car = new BasicCard();
        Card carr = new EquipmentCard();
        Card bc = new Card();
        BasicCard bbc = new BasicCard();
        BasicCard cc = bbc as BasicCard;
        if (cc == null) print(8888);
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public void GenerateDeck()
    {
        Card card;
        GameObject go;
        string[] str;
        for (int i = 0; i < allCardName.Length; i++)
        {
            str = allCardName[i].Split('_');
            if (int.Parse(str[2]) == 1)
            {
                card = new BasicCard(allCardName[i]);
                go = Instantiate(cardPrefab);         
            }
            else if (int.Parse(str[2]) == 2)
            {
                card = new StratagemCard(allCardName[i]);
                go = Instantiate(cardPrefab);
            }
            else
            {
                card = new EquipmentCard(allCardName[i], int.Parse(str[6]));
                go = Instantiate(cardPrefab);
            }        
            go.GetComponent<SpriteRenderer>().sprite = card.spr;            
            deckInfo.Add(card);
            deck.Add(go);
            //go.GetComponent<CardInfo>().card = deckInfo[deckInfo.Count - 1];
            go.AddComponent<CardInfo>();
            go.GetComponent<CardInfo>().card = card;
            go.name = card.cardSkillType.ToString();
            //go.name = go.GetComponent<CardInfo>().card.skillType.ToString();
        }
    }

    public IEnumerator DisplayCard()
    {

        GameObject go = GameObject.Find("Card");
        go.AddComponent<CardInfo>();
        go.GetComponent<CardInfo>().card = deckInfo[0];
        foreach(var v in deck)
        {
            go.GetComponent<SpriteRenderer>().sprite = v.GetComponent<SpriteRenderer>().sprite;
            Card ci = go.GetComponent<CardInfo>().card = v.GetComponent<CardInfo>().card;
            //Card ci = go.GetComponent<CardInfo>().card;
            text.text = ci.cardType.ToString() + " , " + ci.cardIndex.ToString() + " , " + ci.cardColor.ToString();
            yield return new WaitForSeconds(1f);
        }
        yield return null;
    }
    public void GeneratCard()
    {
        AbstractCardFactor abstractCardFactor;
        Card card;
        GameObject go;
        string[] str;
        for (int i = 0; i < allCardName.Length; i++)
        {
            str = allCardName[i].Split('_');
            if (int.Parse(str[2]) == 1)
            {
                abstractCardFactor = new BasicCardFactor();
                card = abstractCardFactor.CreatCard(allCardName[i]);
                go = Instantiate(cardPrefab);                
            }
            else if (int.Parse(str[2]) == 2)
            {
                abstractCardFactor = new StratagemCardFactor();
                card = abstractCardFactor.CreatCard(allCardName[i]);
                go = Instantiate(cardPrefab);
            }
            else
            {
                abstractCardFactor = new EquipmentCardFactor();
                card = abstractCardFactor.CreatCard(allCardName[i],int.Parse(str[4]));
                go = Instantiate(cardPrefab);      
            }
            cardPrefab.GetComponent<SpriteRenderer>().sprite = card.spr;
            deckInfo.Add(card);
            deck.Add(go);
            go.GetComponent<CardInfo>().card = card;
        }
    }

    /// <summary>
    /// 加载所有卡牌名
    /// </summary>
    /// <returns></returns>
    private string[] GetCardNames()
    {
        //路径  
        string fullPath = "Assets/Resources/Images/";

        if (Directory.Exists(fullPath))
        {
            DirectoryInfo direction = new DirectoryInfo(fullPath);
            FileInfo[] files = direction.GetFiles("*.png", SearchOption.AllDirectories);
            return files.Select(s => Path.GetFileNameWithoutExtension(s.Name)).ToArray();
        }
        return null;
    }
    
    /// <summary>
    /// 洗牌
    /// </summary>
    /// <param name="allCardNames"></param>
    public void Shuffle(string [] allCardNames)
    {
        for (int i = 0; i < allCardNames.Length; i++)
        {
            int num = Random.Range(i, allCardNames.Length);
            string temp = allCardNames[i];
            allCardNames[i] = allCardNames[num];
            allCardNames[num] = temp; 
        }
        GenerateDeck();
    }

    
    public void TakeCard(int cardCount)
    {

    }
}

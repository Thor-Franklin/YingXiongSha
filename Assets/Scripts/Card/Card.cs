using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public  class Card{
    public string cardName;
	public Sprite spr;
    public Suits suits;
    public CardColor cardColor;
    public CardType cardType;
    public Weight cardPoint;
    public CardSkillType cardSkillType;
    public AttackTargetNumber attackTargetNumber;//no assignment
    public bool isActively = false;
    public bool isCanPlayKill = true;
    public Skill skill;
    public int cardIndex;
    public bool isSelect;

    public Card() { }

    /// <summary>
    /// Card constuctor
    /// </summary>
    /// <param name="cardName">cardName is the sprite name and this param like 1_2_1_3_1, 
    /// it means Suits_Point_CardType_CardSkillType_AttackRange(if it is equipment,otherwise ignore the AttackRange) </param>
    public Card(string cardName)
    {
        this.cardName = cardName;
        var splits = cardName.Split('_');
        switch (splits[0])
        {
            case "1":
                suits = Suits.Spade;
                cardColor = CardColor.Black;               
                break;
            case "2":
                suits = Suits.Heart;
                cardColor = CardColor.Red;              
                break;
            case "3":
                suits = Suits.Club;
                cardColor = CardColor.Black;                
                break;
            case "4":
                suits = Suits.Diamond;
                cardColor = CardColor.Red;
                break;
            default:
                throw new System.Exception(string.Format("卡牌文件名{0}非法！", cardName));
        }
        cardIndex = int.Parse(splits[1]) % 14;
        cardType = (CardType)int.Parse(splits[2]);
        cardSkillType = (CardSkillType)int.Parse(splits[3]);
        if (int.Parse(splits[4]) == 1)
        {
            isActively = true;
        }
        if (cardType == CardType.Equipment || cardSkillType == CardSkillType.手捧雷)
        {
            attackTargetNumber = AttackTargetNumber.Self;
        }
        else
        {
            attackTargetNumber = (AttackTargetNumber)int.Parse(splits[5]);
        }
        spr = Resources.Load("Images/" + cardName, typeof(Sprite)) as Sprite;
        if (spr == null) Debug.Log("Sprite load fail");
    }
   
   
}

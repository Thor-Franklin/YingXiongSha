using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : AbstractPlayer
{
   
    private bool playCardBtnIsPressed;
    private bool isThisRoundCanPlayCard;


    // Use this for initialization
    void Start()
    {
        abstractHero = new ZhuYuanZhang(CardMeddiator.instance, new HeroData("ZhuYuanZhang", 4));
        if (abstractHero.heroData == null) Debug.Log("55555555555");
        //StartCoroutine(PlayCardCountdown()); 
    }



    public IEnumerator PlayCardCountdown()
    {
        int addTime = 0;
        while (addTime != 10 && !playCardBtnIsPressed)
        {
            yield return new WaitForSeconds(1);
            addTime++;
            Debug.Log("add time is " + addTime);
        }
    }

    /// <summary>
    /// Play Card in player's round
    /// </summary>
    private AskForCardEventArgs PlayCard()
    {
        if (abstractHero.heroData.isMyRound.Value)
        {
            AskForCardEventArgs e = new AskForCardEventArgs();
            e.attacker = abstractHero;
            e.weaponEffect = abstractHero.heroData.weapEff;
            e.attackerCard = abstractHero.heroData.CacheCards.Value;
            e.targetPlayer = abstractHero.heroData.CacheTargetPlayer.Value;
            return e;
        }
        return null;
    }


    /// <summary>
    /// Validate the play card operation
    /// </summary>
    public bool ValidPlayCard()
    {
        return false;
    }


    public void PlayCardButtonClick()
    {
        playCardBtnIsPressed = true;
        //playCardBtn.onClick.AddListener(delegate () { abstractHero.absMediator.Notify(PlayCard()); });
        
        //playCardBtn.gameObject.SetActive(false);
    }


    public void CancelPlayCardButtonClick()
    {
        playCardBtnIsPressed = false;
        isThisRoundCanPlayCard = false;
        //cancelPlayCardBtn.gameObject.SetActive(false);
    }


    public bool IsPlayerCanPlayCard()
    {
        playCardBtnIsPressed = false;
        return false;
    }

}

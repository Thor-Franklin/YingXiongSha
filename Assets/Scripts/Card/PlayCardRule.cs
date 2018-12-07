using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayCardRule
{
    public static bool ValidEquipGrenade(HeroData heroData)
    {
        foreach (var item in heroData.JudgeCards.Value)
        {
            if (item.GetComponent<CardInfo>().card.cardSkillType == CardSkillType.手捧雷)
            {
                return false;
            }
        }
        return true;
    }

    public static bool ValidPlayCard(HeroData heroData)
    {
        if (heroData.CacheCards.Value.Count != heroData.canPlayCardNum.Value) // judge play card count
        {
            return false;
        }
        if (heroData.isMyRound.Value) 
        {
            if (!heroData.CurHandCards.Value[0].GetComponent<CardInfo>().card.isActively)
            {
                Debug.Log("You can't play this card actively!");
                return false;
            }
        }
        if (heroData.CacheCards.Value[0].GetComponent<CardInfo>().card != null)
            if (heroData.CacheTargetPlayer.Value.Count != heroData.targetNumber.Value)//asign target count
            {
                return false;
            }
        return true;
    }


    /// <summary>
    /// Decide whether to play the card actively or passively
    /// </summary>
    /// <param name="heroData"></param>
    /// <returns>ture means paly card actively, false conversely </returns>
    public static bool ValidPlayCardType(HeroData heroData)
    {
        return heroData.isMyRound.Value;   
    }


    public static bool ValidDistance(HeroData playerHeroData, HeroData targetHeroData)
    {
        if (playerHeroData.attackRange.Value < targetHeroData.defenseRange.Value)
        {
            return false;
        } 
        return true;
    }


    public static bool ValidPlayKill(HeroData heroData)
    {

        if (heroData.isMyRound.Value)
            return true;
        return false;
                
    }

} 


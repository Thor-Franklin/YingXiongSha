using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public bool isInitiative;
    public bool isAOE;

   public static void TriggerWeaponEffect(AbstractHero attacker)
    {
        switch (attacker.heroData.weapEff)
        {
            case WeaponEffect.虎符:
                attacker.heroData.isUnlimitedKill.Set(true);
                break;
            case WeaponEffect.芦叶枪:
                if (attacker.heroData.CurHandCards.Value.Count>= 2)
                {
                    if (attacker.heroData.CurHandCards.Value.Count == 2)
                    {
                        //set the first cardInfo to target card
                        attacker.heroData.CacheCards.Value[0].GetComponent<CardInfo>().card = CardConvert(attacker.heroData.CacheCards.Value.ToArray(), CardSkillType.杀);
                        //if launch jiquan to get the two card，the first cardInfo need reset
                    }
                }
                break;
            case WeaponEffect.盘龙棍:
                attacker.heroData.isHuntDown.Set(true);

                break;
            case WeaponEffect.龙鳞刀:
                attacker.heroData.isCanRemove2Card.Set(true);
                break;
            case WeaponEffect.霸王弓:

            case WeaponEffect.狼牙棒:                                            
                if ( attacker.heroData.CurHandCards.Value.Count == 1 )
                {
                    attacker.heroData.targetNumber.Set(3);
                }
                break;
        }
    }


    public static Card CardConvert(GameObject [] sourceCard, CardSkillType wantToConvert)
    {
        Card convertTo = new Card(sourceCard[0].GetComponent<CardInfo>().card.cardName);
        convertTo.cardSkillType = wantToConvert;
        return convertTo;
    }



    /// <summary>
    /// Kill
    /// </summary>
    /// <param name="e"></param>
    public AskForCardEventArgs Kill(AbstractHero attacker,AbstractHero target, AbstractMediator cardMed)
    {
        
        AskForCardEventArgs e = new AskForCardEventArgs();
        CardMeddiator cm = (CardMeddiator)cardMed; 
        
        if (attacker.heroData.weapEff != WeaponEffect.None)
        {
            TriggerWeaponEffect(attacker);
        }
        // if player has other automatic trigger skill to launch,coding here(e.g.精准,豹头，or some skill that can direct hit on target before ask for shan )
        bool hasCard = cardMed.QueryCard(target , CardSkillType.闪);
        if (hasCard)//has shan,ask for play card
        {
            cm.AskForPlayCard(target, CardSkillType.闪);
            //calculate damage
            ((CardMeddiator)cardMed).CalculateDamage(target);
            //launch skill to cancel damage 
        }
        return e;
    }


}

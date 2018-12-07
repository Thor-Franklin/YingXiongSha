using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardMeddiator : AbstractMediator {

    private List<AbstractPlayer> ap = new List<AbstractPlayer>();
    public static CardMeddiator instance;
    
    private void Awake()
    {
        if (instance ==null)
        {
            instance = this;
        }
    } 

    public override void Notify(AskForCardEventArgs e)
    {
        base.Notify(e);
        Timer timer = Timer.CreateTimer();
        timer.StartTiming(10)
    }


    /// <summary>
    /// Respond Mediator ask for specified card
    /// </summary>
    /// <param name="card">the card need to play</param>
    /// <returns></returns>
    public override bool QueryCard(AbstractHero queryTarget, CardSkillType card)
    {
        foreach (var v in queryTarget.heroData.CurHandCards.Value) //Bug Note: if player equip the 芦叶枪 and his hand card count bigger than two ,this place has bug.
        {
            if (v.name == card.ToString())
            {
                return true;
            }
            // if the player have skill to replace the request card, also can play card
        }
        return false;
    }


    public override bool SkillReplaceAskForCard(PlayerSkillType playerSkiType)
    {

        return false;
    }
    // Use this for initialization
    void Start () {
        ap = GameController.instance.allPlayers;
        
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    IEnumerator AskForLaunchSkill()
    {
        yield return null;
       
    }

    IEnumerator WaitForPlayCard(AbstractHero targetPlayer, CardSkillType cardSkiTp)
    {
        float curTime = Time.time;
        
        yield return new WaitUntil(() => 
        {
            if (Time.time - curTime > 10)
                return true;
            return AskForPlayCard(targetPlayer, cardSkiTp);
        });
    }

    public bool AskForPlayCard(AbstractHero targetPlayer, CardSkillType cardSkiTp)
    {
        if ( targetPlayer.heroData.CacheCards.Value[0].GetComponent<CardInfo>().card.cardSkillType ==cardSkiTp)
        {
            //play card button active true
        }
        else { Debug.Log("You can't play this card!");  }

        return false;
    }

    public void CalculateDamage(AbstractHero damageTarget)
    {
        damageTarget.heroData.curHP.Set(damageTarget.heroData.curHP.Value - 1);

    }


}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractMediator : MonoBehaviour {
    public int damage;
    public delegate void RequestCardEventHandler(object obj, AskForCardEventArgs e);
    public event RequestCardEventHandler RequestCard; //

    public abstract bool QueryCard(AbstractHero target, CardSkillType st);

    public abstract bool SkillReplaceAskForCard(PlayerSkillType playerSkiType);

   

    public void Register()
    {

    }

    public void UnRegister()
    {

    }

    public virtual void Notify(AskForCardEventArgs e)
    {
        if (RequestCard !=null)
        {
            RequestCard(this,e);
        }
    }
	
}

public class AskForCardEventArgs:EventArgs
{
    public AbstractHero attacker;
    public int targetCount;
    public List <GameObject> targetPlayer;
    public WeaponEffect weaponEffect;
    public ArmorEffect armorEffect;
    public List <GameObject> attackerCard;


}

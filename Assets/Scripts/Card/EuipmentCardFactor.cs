using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentCardFactor : AbstractCardFactor
{
    public override Card CreatCard(string name)
    {
        return null;
    }

    public override Card CreatCard(string name, int attackRange)
    {
        return new EquipmentCard(name, attackRange);
        
    }
}

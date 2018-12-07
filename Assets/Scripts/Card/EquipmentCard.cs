using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentCard : Card {

    public int attackRange;

    public EquipmentCard() { }
    public EquipmentCard(string name,int attackRange ):base(name)
    {
        this.attackRange = attackRange;
    }

   

   
}

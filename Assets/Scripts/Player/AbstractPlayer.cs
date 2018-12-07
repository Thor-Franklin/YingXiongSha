using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class AbstractPlayer {

    public AbstractHero abstractHero;
    
    public AbstractPlayer() { }   

    protected virtual int GetTargetNubmer(Card card)
    {
        return (int)card.attackTargetNumber; 
    }


}

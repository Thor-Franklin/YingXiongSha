using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractHero {
    public AbstractMediator absMediator;
    public HeroData heroData;



    public AbstractHero(AbstractMediator mediator,HeroData hd)
    {
        absMediator = mediator;
        mediator.RequestCard += RespondToMediator;
        heroData = hd;
    }

    public abstract void RespondToMediator(object obj, AskForCardEventArgs e);
}

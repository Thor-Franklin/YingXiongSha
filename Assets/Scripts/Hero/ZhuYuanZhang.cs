using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZhuYuanZhang : AbstractHero  {

    public ZhuYuanZhang(AbstractMediator mediator, HeroData hd) : base(mediator, hd)
    {
    }

    public void QiangYun()
    {
        if (heroData.CurHandCards.Value.Count==0)
        {
            //take two cards
        }
    }

    public override void RespondToMediator(object obj, AskForCardEventArgs e)
    {
        throw new NotImplementedException();
    }
}

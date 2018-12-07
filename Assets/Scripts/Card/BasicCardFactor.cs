using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCardFactor : AbstractCardFactor {



    public override Card CreatCard(string name)
    {
        return new BasicCard(name);
        
    }

    public override Card CreatCard(string name, int attackRange)
    {
        return null;
    }

}

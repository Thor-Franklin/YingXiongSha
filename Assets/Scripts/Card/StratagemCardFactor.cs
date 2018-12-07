using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StratagemCardFactor : AbstractCardFactor {

    public override Card CreatCard(string name)
    {
        return new StratagemCard(name);
      
    }

    public override Card CreatCard(string name, int attackRange)
    {
        return null;
    }
    
}

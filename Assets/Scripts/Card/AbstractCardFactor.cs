using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractCardFactor {

    public abstract Card CreatCard(string name, int attackRange);
    public abstract Card CreatCard(string name);
}

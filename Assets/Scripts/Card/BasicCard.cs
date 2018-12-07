using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCard : Card {
    string cName;

   public BasicCard(){ }
    public BasicCard(string name):base (name) { }

   

    


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool Kill(params Player[] target)
    {

        return false;
    }
}

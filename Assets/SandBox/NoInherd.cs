using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoInherd {
    private readonly TeContext _teContext;

    public TeContext TeContext
    {
        get
        {
            return _teContext;
        }
    }

    public NoInherd()
    {
        _teContext = new TeContext();
        Start();
        Debug.Log("execute Start()");
    } 
	// Use this for initialization
	void Start () {
        TeContext.Colorer = Color.blue;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

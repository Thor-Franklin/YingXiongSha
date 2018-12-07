using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour  {
    public static GameController instance;
    public List<AbstractPlayer> allPlayers = new List<AbstractPlayer>();
    public int curPlayerCount;
    public int maxPlayerCount;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
 
    void Start()
    {
               
        
    }
	
}

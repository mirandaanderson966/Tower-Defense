using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

    public static int Money;
    public int startMoney = 100;

    public static int Lives;
    public int startLives = 20;

    public static int Rounds;

    void Start()
    {
        Money = startMoney; //static variables carry inbetween scenes. 
        Lives = startLives;

        Rounds = 0; 
    } 


}

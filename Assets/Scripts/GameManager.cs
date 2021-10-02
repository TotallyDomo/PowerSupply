using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton
{
    [SerializeField, Header("Power")]
    float currentPower;
    [SerializeField]
    float minPower, MaxPower;

    [SerializeField, Header("Heat")]
    float currentHeat;
    [SerializeField]
    float MaxHeat;

    [SerializeField, Header("Waste")]
    float currentWaste;
    [SerializeField]
    float MaxWaste;

    protected override void Awake()
    {
        base.Awake();
        currentPower = currentHeat = currentWaste = 0;
    }

    public void AddPower(float amount)
    {
        currentPower += amount;

        if (currentPower > MaxPower)
        {
            //boom
        }
        else if (currentPower < minPower)
        {
            // you are fired
        }
    }

}

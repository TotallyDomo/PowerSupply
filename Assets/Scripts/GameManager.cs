using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton
{
    [SerializeField]
    float power, heat, waste;

    float Power => power;
    float Heat => heat;
    float Waste => waste;

    protected override void Awake()
    {
        base.Awake();
        power = heat = waste = 0;
    }

    public void AddPower(float amount)
    {
        power += amount;
    }

}

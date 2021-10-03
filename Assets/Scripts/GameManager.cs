using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
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

    public static Action<float> UpdatePower;
    public static Action<float> UpdateHeat;

    void Awake()
    {
        UpdatePower = null;
        UpdateHeat = null;
        UpdatePower += OnUpdatePower;
        UpdateHeat += OnUpdateHeat;
    }

    public void OnUpdatePower(float amount)
    {
        currentPower = amount;

        if (currentPower > MaxPower)
        {
            UI.GameOver("Reactor produced too much power, which fried all electronic devices in the city. As the lead engineer of the power plant, you are fired! ");
        }
        else if (currentPower < minPower)
        {
            UI.GameOver("Reactor produced too little power, which caused a power outage. As the lead engineer of the power plant, you are fired!");
        }

    }

    void OnUpdateHeat(float amount)
    {
        currentHeat = amount;

        if (currentHeat > MaxHeat)
        {
            UI.GameOver("Reactor got overheated and melted down! All hope is lost.");
        }
    }

}

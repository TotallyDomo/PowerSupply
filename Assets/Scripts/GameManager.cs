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
    public static Action<float> AddHeat;

    void Awake()
    {
        UpdatePower = null;
        AddHeat = null;
        UpdatePower += OnUpdatePower;
        AddHeat += OnAddHeat;
    }

    public void OnUpdatePower(float amount)
    {
        currentPower = amount;

        if (currentPower > MaxPower)
        {
            //boom
        }
        else if (currentPower < minPower)
        {
            // you are fired
        }
        else
        {
            //currentPower = 0;
        }
    }

    void OnAddHeat(float amount)
    {
        currentHeat += amount;

        if (currentHeat > MaxHeat)
        {
            // boom
        }
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField, Header("Power")]
    float currentPower;
    [SerializeField]
    float minPower, MaxPower;
    [SerializeField]
    Slider powerSlider;

    [SerializeField, Header("Heat")]
    float currentHeat;
    [SerializeField]
    float MaxHeat;
    [SerializeField]
    Slider heatSlider;

    [SerializeField, Header("Waste")]
    float currentWaste;
    [SerializeField]
    float MaxWaste;
    [SerializeField]
    Slider wasteSlider;


    public static Action<float> UpdatePower;
    public static Action<int> UpdateHeat;
    public static Action<int> UpdateWaste;

    void Awake()
    {
        UpdatePower = null;
        UpdateHeat = null;
        UpdateWaste = null;
        UpdatePower += OnUpdatePower;
        UpdateHeat += OnUpdateHeat;
        UpdateWaste += OnUpdateWaste;
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

        powerSlider.value = amount;
        heatSlider.value = amount;
    }

    void OnUpdateHeat(int amount)
    {
        currentHeat = amount;
        heatSlider.value = amount;

        if (currentHeat > MaxHeat)
        {
            UI.GameOver("Reactor got overheated and melted down! All hope is lost.");
        }

    }

    void OnUpdateWaste(int amount)
    {
        currentWaste = amount;
        wasteSlider.value = amount;

        if (currentWaste > MaxWaste)
        {
            UI.GameOver("The safety comitee has closed the reactor due to overwhelming amount of radioactive waste! You are now unemployed.");
        }
    }

}

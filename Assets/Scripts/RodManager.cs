using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodManager : MonoBehaviour
{
    [SerializeField]
    Rod[] rods;

    float currentPower;

    void Update()
    {
        currentPower = 0;
        foreach (var rod in rods)
            currentPower += rod.GeneratePower();
        GameManager.UpdatePower(currentPower);
    }
}

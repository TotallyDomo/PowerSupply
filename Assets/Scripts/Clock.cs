using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public float TickTimer { get; private set; }
    float currentTime;

    public static Action OnTick;

    void Awake()
    {
        OnTick = null;
        TickTimer = 1f;
        currentTime = 0f;
    }

    void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0f)
        {
            currentTime = TickTimer;
            OnTick.Invoke();
        }
    }
}

﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    public float TickTimer { get; private set; }
    float currentTime;
    public static float time;

    public static Action OnTick;

    void Awake()
    {
        OnTick = null;
        TickTimer = 2f;
        currentTime = 0f;
        time = 0f;
    }

    void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0f && !UI.GameOverState)
        {
            TickTimer -= 0.03f;
            currentTime = TickTimer;
            OnTick.Invoke();
        }

        time += Time.deltaTime;
    }
}

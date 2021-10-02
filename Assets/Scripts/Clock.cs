using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : Singleton
{
    public float TickTimer { get; private set; }
    float currentTime;

    public static Action OnTick;

    protected override void Awake()
    {
        base.Awake();
        OnTick = null;
        TickTimer = 1f;
        currentTime = 0f;
    }

    // Update is called once per frame
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

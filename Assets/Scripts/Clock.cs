using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : Singleton
{
    public float TickTimer { get; private set; }

    public static Action OnTick;

    protected override void Awake()
    {
        base.Awake();
        OnTick = null;
        TickTimer = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

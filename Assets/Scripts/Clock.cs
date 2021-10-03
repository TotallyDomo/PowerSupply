using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [SerializeField]
    float TickTimer;
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
            TickTimer *= 0.985f;
            if (TickTimer < 0.5f)
                TickTimer = 0.5f;
            currentTime = TickTimer;
            OnTick.Invoke();
        }

        time += Time.deltaTime;
    }
}

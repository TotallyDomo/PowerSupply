﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashManager : Singleton
{
    [SerializeField]
    GameObject[] trashPrefabs;

    [SerializeField]
    Vector2 spawnRangeX, spawnRangeY;

    int index;
    Vector2 spawnPoint;

    protected override void Awake()
    {
        base.Awake();
        Clock.OnTick += OnTick;

    }

    void OnTick()
    {
        index = Random.Range(0, trashPrefabs.Length);
        spawnPoint.x = Random.Range(spawnRangeX.x, spawnRangeX.y);
        spawnPoint.y = Random.Range(spawnRangeY.x, spawnRangeY.y);

        Instantiate(trashPrefabs[index], spawnPoint, Quaternion.Euler(0, 0, Random.Range(0, 360)));
    }

}
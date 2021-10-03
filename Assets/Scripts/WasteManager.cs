using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasteManager : MonoBehaviour
{
    [SerializeField]
    GameObject wastePrefab;

    [SerializeField]
    Transform spawnPoint;

    int tickCount;
    void Start()
    {
        tickCount = 0;
        Clock.OnTick += OnTick;
    }

    void OnDestroy() => Clock.OnTick -= OnTick;

    void OnTick()
    {
        tickCount++;
        if (tickCount % 4 == 0)
        {
            Instantiate(wastePrefab, spawnPoint.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
            GameManager.UpdateWaste(1);
        }
    }
}

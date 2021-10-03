using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashManager : MonoBehaviour
{
    [SerializeField]
    GameObject[] trashPrefabs;

    [SerializeField]
    Vector2 spawnRangeX, spawnRangeY;

    int index;
    Vector2 spawnPoint;

    int trashCount;

    void Start()
    {
        Clock.OnTick += OnTick;
    }

    void OnDestroy() => Clock.OnTick -= OnTick;

    void OnTick()
    {
        index = Random.Range(0, trashPrefabs.Length);
        spawnPoint.x = Random.Range(spawnRangeX.x, spawnRangeX.y);
        spawnPoint.y = Random.Range(spawnRangeY.x, spawnRangeY.y);

        Instantiate(trashPrefabs[index], spawnPoint, Quaternion.Euler(0, 0, Random.Range(0, 360)));
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        trashCount++;
        GameManager.UpdateHeat(trashCount);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        trashCount--;
        GameManager.UpdateHeat(trashCount);
    }

}

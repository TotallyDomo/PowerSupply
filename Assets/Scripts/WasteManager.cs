using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasteManager : MonoBehaviour
{
    [SerializeField]
    GameObject wastePrefab;

    [SerializeField]
    Transform spawnPoint;

    int wasteCount;
    void Awake()
    {
        Clock.OnTick += OnTick;
    }

    void OnDestroy() => Clock.OnTick -= OnTick;

    void OnTick()
    {
        wasteCount++;
        Instantiate(wastePrefab, spawnPoint.position, Quaternion.Euler(0, 0, Random.Range(0, 360)));
        GameManager.UpdateWaste(wasteCount);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        wasteCount--;
        GameManager.UpdateWaste(wasteCount);
        Destroy(collision.gameObject);
    }

}

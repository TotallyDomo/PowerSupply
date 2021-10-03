using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class Trash : MonoBehaviour
{

    [SerializeField]
    Vector2 scaleRange;

    [SerializeField]
    float minimalScale = 0.05f;

    [SerializeField]
    Vector2Int clicksRange = new Vector2Int(2, 6);

    int clicksToDestroy, currentClicks;
    Vector3 originalScale;
    Vector2 velocity;


    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        float scale = Random.Range(scaleRange.x, scaleRange.y);
        transform.localScale = Vector3.one * scale;
        originalScale = transform.localScale;

        clicksToDestroy = Random.Range(clicksRange.x, clicksRange.y);
        currentClicks = clicksToDestroy;

        velocity = Vector2.right * Random.Range(1.25f, 3f);

        Destroy(gameObject, 90f);
    }

    void Update()
    {
        rb.velocity = velocity;
    }


    void OnMouseDown()
    {
        currentClicks--;
        transform.localScale = originalScale * currentClicks / clicksToDestroy;

        if (transform.localScale.x < minimalScale || currentClicks <= 0)
            Destroy(gameObject);
    }
}

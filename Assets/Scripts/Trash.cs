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
    Vector2 scaleDecreaseRange = new Vector2(0.02f, 0.2f);

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

        clicksToDestroy = Random.Range(2, 7);
        currentClicks = clicksToDestroy;

        velocity = Vector2.right * Random.Range(0.8f, 2.0f);
    }

    void Update()
    {
        rb.velocity = velocity;
    }


    void OnMouseDown()
    {
        currentClicks--;
        transform.localScale = originalScale * currentClicks / clicksToDestroy;

        if (transform.localScale.x < minimalScale)
            transform.localScale = new Vector3(minimalScale, minimalScale, minimalScale);

        if (currentClicks <= 0)
            Destroy(gameObject);
    }
}

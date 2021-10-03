using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waste : MonoBehaviour
{
    [SerializeField]
    Vector2 scaleRange;

    Rigidbody2D rb;

    Vector3 prevMousePos;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnMouseDown()
    {
        prevMousePos = Input.mousePosition;
        rb.gravityScale = 0f;
        rb.velocity = Vector2.zero;
    }

    void OnMouseUp()
    {
        rb.gravityScale = 1f;
    }

    void OnMouseDrag()
    {
        var mouseDelta = (prevMousePos - Input.mousePosition) * Time.deltaTime;

        rb.velocity -= new Vector2(mouseDelta.x, mouseDelta.y);

        prevMousePos = Input.mousePosition;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager.UpdateWaste(-1);
        Destroy(gameObject);
    }
}

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
        rb.isKinematic = true;
    }

    void OnMouseUp()
    {
        rb.isKinematic = false;
    }

    void OnMouseDrag()
    {
        var mouseDelta = (prevMousePos - Input.mousePosition) * Time.deltaTime;

        rb.velocity -= new Vector2(mouseDelta.x, mouseDelta.y);

        prevMousePos = Input.mousePosition;
    }
}

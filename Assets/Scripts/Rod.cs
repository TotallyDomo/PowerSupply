using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rod : MonoBehaviour
{

    [SerializeField]
    float basePowerOutput = 1f, sinkingSpeed = 0.2f;

    [SerializeField]
    float minY, maxY;

    float tempY, mouseDeltaY;
    Vector3 rodPos, prevMousePos;

    bool isSinking = true;

    void Awake()
    {
        rodPos = transform.position;
    }

    void Update()
    {
        GeneratePower();

        if (isSinking)
            Sink();
    }

    void GeneratePower()
    {

    }

    void Sink()
    {
        tempY = transform.position.y;

        if (tempY > minY)
        {
            tempY -= sinkingSpeed * Time.deltaTime;
            Mathf.Max(tempY, minY);
        }

        rodPos.y = tempY;
        transform.position = rodPos;
    }

    void OnTick()
    {

    }

    void OnMouseDown()
    {
        isSinking = false;
        prevMousePos = Input.mousePosition;
    }

    void OnMouseUp()
    {
        isSinking = true;
    }

    void OnMouseDrag()
    {
        mouseDeltaY = (prevMousePos.y - Input.mousePosition.y) * Time.deltaTime;
        rodPos.y -= mouseDeltaY;

        rodPos.y = Mathf.Clamp(rodPos.y, minY, maxY);

        transform.position = rodPos;

        prevMousePos = Input.mousePosition;
    }

    void OnDestroy()
    {
        Clock.OnTick -= OnTick;
    }
}

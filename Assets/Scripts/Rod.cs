using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rod : MonoBehaviour
{

    [SerializeField]
    float basePowerOutput = 1f, sinkingSpeed = 0.18f;

    float extraOutput = 0f;

    [SerializeField]
    float minY, maxY;

    float tempY, mouseDeltaY;
    Vector3 rodPos, prevMousePos;

    int tickCount;

    bool isSinking = true;
    float stopTime = 2f;
    Coroutine sinkingCoroutine;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rodPos = transform.position;
        Clock.OnTick += OnTick;
    }

    void OnTick()
    {
        tickCount++;
        if (tickCount % 10 == 0)
        {
            basePowerOutput += 0.05f;
            sinkingSpeed += 0.02f;
            stopTime -= 0.05f;
        }
    }

    void Update()
    {
        if (isSinking)
            Sink();

        if (transform.position.y == minY)
        {
            extraOutput += 0.1f * Time.deltaTime;
        }
        else
            extraOutput -= 0.1f * Time.deltaTime;

        extraOutput = Mathf.Clamp01(extraOutput);

        spriteRenderer.color = new Color(1, 1-extraOutput, 1-extraOutput);

    }

    public float GeneratePower()
    {
        return Mathf.Abs(transform.position.y - maxY) *(basePowerOutput + extraOutput);
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

    void OnMouseDown()
    {
        isSinking = false;
        prevMousePos = Input.mousePosition;
    }

    void OnMouseUp()
    {
        if (sinkingCoroutine != null)
            StopCoroutine(sinkingCoroutine);
        sinkingCoroutine = StartCoroutine(delayedSinking());
    }

    IEnumerator delayedSinking()
    {
        yield return new WaitForSeconds(stopTime);
        isSinking = true;
        sinkingCoroutine = null;
    }

    void OnMouseDrag()
    {
        mouseDeltaY = (prevMousePos.y - Input.mousePosition.y) * Time.deltaTime;
        rodPos.y -= mouseDeltaY;

        rodPos.y = Mathf.Clamp(rodPos.y, minY, maxY);

        transform.position = rodPos;

        prevMousePos = Input.mousePosition;
    }
}

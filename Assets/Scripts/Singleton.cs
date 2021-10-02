using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    public static Singleton I { get; private set; }

    protected virtual void Awake()
    {
        //if (I != null && I != this)
        //{
        //    Destroy(gameObject);
        //}
        //else
            I = this;
    }

    protected virtual void OnDestroy()
    {
        I = null;
    }
}

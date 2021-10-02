using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : Singleton
{

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
    }

}

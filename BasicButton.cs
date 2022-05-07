using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicButton : MonoBehaviour
{

    public bool triggered;
    internal void Trigger()
    {
        triggered = true;
    }

    internal void Untrigger()
    {
        triggered = false;
    }
}

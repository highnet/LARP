using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsZone : MonoBehaviour
{

    public new bool enabled;

    private void OnMouseEnter()
    {
        enabled = true;
    }

    private void OnMouseExit()
    {
        enabled = false;
    }
}

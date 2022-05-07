using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicButtonSwitchTriggerArea : MonoBehaviour
{
    public BasicButton basicButton;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Button Switch") {
            basicButton.Trigger();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Button Switch")
        {
            basicButton.Untrigger();
        }
    }
}

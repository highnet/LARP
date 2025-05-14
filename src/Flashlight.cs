using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{

    public new Light light;
    public BasicButton basicButton;

    // Update is called once per frame
    private void FixedUpdate()
    {
        light.enabled = basicButton.triggered;
    }
}

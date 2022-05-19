using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{

    public Timescale timescale;
    public GameObject pivot;
    public float angularSpeed;
    public bool reverse;

    private void Start()
    {
        timescale = GameObject.FindGameObjectWithTag("Timescale").GetComponent<Timescale>();

    }
    private void FixedUpdate()
    {

        if (timescale.timeState == Timescale.TimeState.Playing)
        {
            transform.RotateAround(pivot.transform.position, reverse ? Vector3.forward : Vector3.back, angularSpeed * Time.deltaTime);
        }
    }
}

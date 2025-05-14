using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinballFlipper : MonoBehaviour
{
    public new HingeJoint hingeJoint;
    public Timescale timescale;


    private void Start()
    {
        hingeJoint = GetComponent<HingeJoint>();
        timescale = GameObject.FindGameObjectWithTag("Timescale").GetComponent<Timescale>();

    }

    public IEnumerator ActivateFlipper()
    {
        hingeJoint.useMotor = true;
        yield return new WaitForSeconds(.5f);
        hingeJoint.useMotor = false;


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (timescale.timeState == Timescale.TimeState.Playing)
        {
            StartCoroutine(ActivateFlipper());
        }
    }

}

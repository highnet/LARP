using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryRecorder : MonoBehaviour
{

    public List<Vector3> positions;
    public List<Quaternion> rotations;
    public Timescale timescale;
    public new Rigidbody rigidbody;

    public bool backtracking;

    private void Start()
    {
        positions = new List<Vector3>();
        rotations = new List<Quaternion>();
        timescale = GameObject.FindGameObjectWithTag("Timescale").GetComponent<Timescale>();
        rigidbody = GetComponent<Rigidbody>();
    }

    public void AppendPosition()
    {
        positions.Add(transform.position);
    }
    public void AppendRotation()
    {
        rotations.Add(transform.rotation);
    }

    private void FixedUpdate()
    {
        if (timescale.timeState == Timescale.TimeState.Playing)
        {
            positions.Add(transform.position);
            rotations.Add(transform.rotation);
        }


        if (timescale.timeState == Timescale.TimeState.Backtracking)
        {
            if (rigidbody != null)
            {
                rigidbody.velocity = Vector3.zero;
                rigidbody.angularVelocity = Vector3.zero;
            }


            if (positions.Count - 1 > 0)
            {
                transform.position = positions[positions.Count - 1];
                positions.RemoveAt(positions.Count - 1);
            }
            else if (positions.Count == 1)
            {
                transform.position = positions[0];
                backtracking = false;
            }


            if (rotations.Count - 1 > 0)
            {
                transform.rotation = rotations[rotations.Count - 1];
                rotations.RemoveAt(rotations.Count - 1);
            }
            else if (rotations.Count == 1)
            {
                transform.rotation = rotations[0];
                backtracking = false;
            }
        }




    }
}

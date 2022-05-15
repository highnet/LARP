using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryRecorder : MonoBehaviour
{

    public List<Vector3> positions;
    public List<Quaternion> rotations;
    public Timescale timescale;
    public new Rigidbody rigidbody;
    public TrailRenderer trailRenderer;

    public bool backtracking;

    private void Start()
    {
        positions = new List<Vector3>();
        rotations = new List<Quaternion>();
        timescale = GameObject.FindGameObjectWithTag("Timescale").GetComponent<Timescale>();
        rigidbody = GetComponent<Rigidbody>();
        trailRenderer = GetComponent<TrailRenderer>();
    }

    public void EnableTrail()
    {

        if (trailRenderer != null)
        {

            trailRenderer.enabled = true;
            trailRenderer.emitting = true;
        }
    }

    public void DisableTrail()
    {
        if (trailRenderer != null)
        {
            trailRenderer.emitting = false;
            trailRenderer.Clear();
            trailRenderer.enabled = false;
        }
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
                transform.rotation = rotations[rotations.Count - 1];

                positions.RemoveAt(positions.Count - 1);
                rotations.RemoveAt(rotations.Count - 1);
            }
            else if (backtracking && positions.Count == 1)
            {
                transform.position = positions[0];

                if (this.tag == "Boxing Glove")
                {
                    GetComponent<BoxingGloveRod>().enabled = false;
                }
                else if (this.tag == "Trap Door")
                {
                    rigidbody.constraints = RigidbodyConstraints.FreezePosition;
                    GetComponentInParent<TrapDoor>().activated = false;
                    GetComponentInParent<TrapDoor>().armed = false;

                }

                backtracking = false;
                DisableTrail();
            }
            }


    }
}

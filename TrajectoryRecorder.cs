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

        StartCoroutine("RecordPositionAndRotation");
        StartCoroutine("BackTrackTrajectory");

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

    public void ResetObjectStates()
    {

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
        else if (this.tag == "Pinball Flipper")
        {
            GetComponent<PinballFlipper>().hingeJoint.useMotor = false;
        }
        else if (this.tag == "Candle Stick")
        {
            Candle candle = GetComponent<Candle>();

            candle.fire.Clear();
            candle.fireSparks.Clear();
            if (candle.beginLit)
            {
                candle.ExtinguishCandle(true);
                candle.LightCandle();
            }
            else
            {
                candle.ExtinguishCandle(true);

            }
        }
        else if (this.tag == "Moving Platform")
        {
            GetComponent<MovingPlatform>().time = 0;
            GetComponent<MovingPlatform>().contacts = new List<GameObject>();
        }
        else if (this.tag == "Dynamite Stick")
        {
            Dynamite dynamite = GetComponent<Dynamite>();

            dynamite.fire.Clear();
            dynamite.fireSparks.Clear();
            if (dynamite.beginLit)
            {
                dynamite.ExtinguishDynamite(true);
                dynamite.LightDynamite();
            }
            else
            {
                dynamite.ExtinguishDynamite(true);

            }
        }
    }

    public IEnumerator RecordPositionAndRotation()
    {
        while (true)
        {
            yield return new WaitForSeconds(.01f);

            if (timescale.timeState == Timescale.TimeState.Playing)
            {
                positions.Add(transform.position);
                rotations.Add(transform.rotation);
            }

        }
    }

    public IEnumerator BackTrackTrajectory()
    {
        while (true)
        {
            yield return new WaitForSeconds(.01f);

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
                    transform.rotation = rotations[0];
                    ResetObjectStates();
                    DisableTrail();

                    backtracking = false;
                }
            }

        }
    }

}

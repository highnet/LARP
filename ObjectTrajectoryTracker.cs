using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTrajectoryTracker : MonoBehaviour
{

    public List<TrajectoryRecorder> playZoneEntityTrajectoryRecorders;
    public Timescale timescale;


    private void Start()
    {
        GameObject pze = GameObject.FindGameObjectWithTag("Play Zone Entities");
        timescale = GameObject.FindGameObjectWithTag("Timescale").GetComponent<Timescale>();


        playZoneEntityTrajectoryRecorders = new List<TrajectoryRecorder>(pze.GetComponentsInChildren<TrajectoryRecorder>());
    }

    public void PrepareObjectsForBacktracking()
    {
        for (int i = 0; i < playZoneEntityTrajectoryRecorders.Count; i++)
        {
            playZoneEntityTrajectoryRecorders[i].backtracking = true;
            playZoneEntityTrajectoryRecorders[i].EnableTrail();

        }
    }

    private void FixedUpdate()
    {
        if (timescale.timeState == Timescale.TimeState.Backtracking)
        {
            bool stillBackTracking = false;
            for (int i = 0; i < playZoneEntityTrajectoryRecorders.Count; i++)
            {
                stillBackTracking = playZoneEntityTrajectoryRecorders[i].backtracking;
            }

            if (!stillBackTracking)
            {

                for (int i = 0; i < playZoneEntityTrajectoryRecorders.Count; i++)
                {
                    playZoneEntityTrajectoryRecorders[i].positions = new List<Vector3>();
                    playZoneEntityTrajectoryRecorders[i].rotations = new List<Quaternion>();

                }
                timescale.Pause();
            }
        }

    }

}

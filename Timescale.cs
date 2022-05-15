using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timescale : MonoBehaviour
{

    public enum TimeState { Paused, Playing, Backtracking }

    public ObjectTrajectoryTracker objectTrajectoryTracker;
    public TimeState timeState;
    public float secondsinPlay;
    public PlayZoneObjectSpawner playZoneObjectSpawner;

    private void Start()
    {
        timeState = TimeState.Paused;
        Time.timeScale = 0.0f;
        objectTrajectoryTracker = GameObject.FindGameObjectWithTag("Object Trajectory Tracker").GetComponent<ObjectTrajectoryTracker>();
        playZoneObjectSpawner = GameObject.FindGameObjectWithTag("Play Zone Object Spawner").GetComponent<PlayZoneObjectSpawner>();

    }

    public void Play()
    {
        if (timeState == TimeState.Backtracking) return;
        if (playZoneObjectSpawner.doingHoverPlacement) return;
        Time.timeScale = 1.0f;

        timeState = TimeState.Playing;
        StartCoroutine("CountSecondsInPlay");
    }

    public void Backtrack()
    {
        if (timeState == TimeState.Backtracking || timeState == TimeState.Paused) return;

        
        Time.timeScale = Mathf.Min(10, Mathf.Max(secondsinPlay , 2.0f));
        secondsinPlay = 0;


        timeState = TimeState.Backtracking;
        objectTrajectoryTracker.PrepareObjectsForBacktracking();

    }

    public void Pause()
    {
        Time.timeScale = 0.0f;
        timeState = TimeState.Paused;
        StopCoroutine("CountSecondsInPlay");

    }

    IEnumerator CountSecondsInPlay()
    {
        for (; ; )
        {
            yield return new WaitForSeconds(1f);
            if (timeState == TimeState.Playing) {
            secondsinPlay++;
            }
        }
    }
}

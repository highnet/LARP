using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timescale : MonoBehaviour
{

    public enum TimeState { Paused, Playing, Backtracking }

    public ObjectTrajectoryTracker objectTrajectoryTracker;
    public TimeState timeState;
    public PlayZoneObjectSpawner playZoneObjectSpawner;
    public PlayLevelUIController playLevelUIController;
    public float playPauseButtonCooldown = 2.0f;
    public float playPauseButtonTimer = 2.0f;


    private void Start()
    {
        Time.timeScale = 0.0f;
        timeState = TimeState.Paused;
        objectTrajectoryTracker = GameObject.FindGameObjectWithTag("Object Trajectory Tracker").GetComponent<ObjectTrajectoryTracker>();
        playZoneObjectSpawner = GameObject.FindGameObjectWithTag("Play Zone Object Spawner").GetComponent<PlayZoneObjectSpawner>();
        playLevelUIController = GameObject.FindGameObjectWithTag("Play Level UI Controller").GetComponent<PlayLevelUIController>();

    }

    private void Update()
    {
        if (playPauseButtonTimer < playPauseButtonCooldown)
        {
            playPauseButtonTimer += Time.unscaledDeltaTime;
        } else if (playPauseButtonTimer > playPauseButtonCooldown)
        {
            playPauseButtonTimer = playPauseButtonCooldown;
        }
    }

    public void PlayPauseButtonPressed()
    {
        if (playPauseButtonTimer == playPauseButtonCooldown)
        {
            if (timeState == TimeState.Paused)
            {
                Play();
            }
            else if (timeState == TimeState.Playing)
            {
                Backtrack();
            }

            playPauseButtonTimer = 0;
        }

    }

    public void Play()
    {
        if (timeState == TimeState.Backtracking) return;
        if (playZoneObjectSpawner.doingHoverPlacement) return;
        playLevelUIController.TogglePlayAndPauseImage();
        objectTrajectoryTracker.PrepareObjectsForPlaying();

        Time.timeScale = 1.0f;

        timeState = TimeState.Playing;
    }

    public void Backtrack()
    {
        if (timeState == TimeState.Backtracking || timeState == TimeState.Paused) return;
        timeState = TimeState.Backtracking;
        objectTrajectoryTracker.PrepareObjectsForBacktracking();
        playLevelUIController.UpdateRewindingElements();
        playLevelUIController.TogglePlayAndPauseImage();


    }

    public void Pause()
    {
        Time.timeScale = 0.0f;
        timeState = TimeState.Paused;
        StopCoroutine("CountSecondsInPlay");
        playLevelUIController.UpdateRewindingElements();


    }

}

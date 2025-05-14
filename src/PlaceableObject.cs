using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableObject : MonoBehaviour
{
    public bool playerOwned;
    public PlayZoneObjectSpawner playZoneObjectSpawner;
    public Outline outline;
    public Vector3 rotationVector;
    public Timescale timescale;
    public InventorySlot sourceInventorySlot;

    private void Start()
    {
        outline = GetComponent<Outline>();

        timescale = GameObject.FindGameObjectWithTag("Timescale").GetComponent<Timescale>();

        playZoneObjectSpawner = GameObject.FindGameObjectWithTag("Play Zone Object Spawner").GetComponent<PlayZoneObjectSpawner>();
    }

    public void HighLightOutline()
    {
        if (outline != null)
        {
            outline.enabled = true;
            outline.OutlineWidth = 10f;
        }

    }

    public void ResetHighlight()
    {
        if (outline != null)
        {
            outline.OutlineWidth = 0f;
            outline.enabled = false;

        }

    }

    private void OnMouseDown()
    {
        if (!playerOwned) return;
        if (!(timescale.timeState == Timescale.TimeState.Paused)) return;
        if (playZoneObjectSpawner.currentlySelected == null)
        {
            playZoneObjectSpawner.currentlySelected = this.gameObject;
            playZoneObjectSpawner.currentlySelectedPlaceableObject = this;
        } else
        {
            playZoneObjectSpawner.PlaceObject();
        }

    }
}

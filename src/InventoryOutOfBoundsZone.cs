using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryOutOfBoundsZone : OutOfBoundsZone
{
    public PlayZoneObjectSpawner playZoneObjectSpawner;
    public GameObject zoneHighlighter;


    private void Start()
    {
        playZoneObjectSpawner = GameObject.FindGameObjectWithTag("Play Zone Object Spawner").GetComponent<PlayZoneObjectSpawner>();

    }

    private void OnMouseEnter()
    {
        if (playZoneObjectSpawner.currentlySelected != null)
        {
            zoneHighlighter.gameObject.SetActive(true);
        }
    }

    private void OnMouseExit()
    {
        if (playZoneObjectSpawner.currentlySelected != null)
        {
            zoneHighlighter.gameObject.SetActive(false);
        }
    }

    private void OnMouseDown()
    {
        if (playZoneObjectSpawner.currentlySelected != null)
        {
            if (playZoneObjectSpawner.currentlySelectedPlaceableObject != null)
            {
                playZoneObjectSpawner.DeleteObject(playZoneObjectSpawner.currentlySelected);
                zoneHighlighter.gameObject.SetActive(false);

            }
        }
    }

}

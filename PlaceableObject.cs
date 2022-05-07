using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceableObject : MonoBehaviour
{
    public bool playerOwned;
    public PlayZoneObjectSpawner playZoneObjectSpawner;

    private void Start()
    {
        playZoneObjectSpawner = GameObject.FindGameObjectWithTag("Play Zone Object Spawner").GetComponent<PlayZoneObjectSpawner>();
    }

    private void OnMouseDown()
    {
        if (playZoneObjectSpawner.currentlySelected == null)
        {
            playZoneObjectSpawner.currentlySelected = this.gameObject;

        } else
        {
            playZoneObjectSpawner.PlaceObject();
        }

    }
}

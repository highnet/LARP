using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayZoneObjectSpawner : MonoBehaviour
{
    public GameObject[] playZoneObjectPrefabs;
    public GameObject playZoneEntities;
    public GameObject currentlySelected;
    public Timescale timescale;
    public ObjectTrajectoryTracker objectTrajectoryTracker;
    public InventoryUI inventoryUI;
    public bool doingHoverPlacement;
    public InventorySlot inventorySlotPlacement;
    public PlaceableObject currentlySelectedPlaceableObject;
    public InventoryOutOfBoundsZone inventoryOutOfBoundsZone;
    public OutOfBoundsZone robotOutOfBoundsZone;

    private void Start()
    {
        timescale = GameObject.FindGameObjectWithTag("Timescale").GetComponent<Timescale>();
        objectTrajectoryTracker = GameObject.FindGameObjectWithTag("Object Trajectory Tracker").GetComponent<ObjectTrajectoryTracker>();
        inventoryUI = GameObject.FindGameObjectWithTag("Inventory UI").GetComponent<InventoryUI>();
    }

    public void BeginHoverPlacementItem(GameObject objectToPlace, InventorySlot slot)
    {
        doingHoverPlacement = true;
        inventorySlotPlacement = slot;
        currentlySelected = GameObject.Instantiate(objectToPlace,new Vector3(100f,100f,0f),objectToPlace.transform.rotation,playZoneEntities.transform);
        currentlySelectedPlaceableObject = currentlySelected.GetComponent<PlaceableObject>();
        currentlySelectedPlaceableObject.sourceInventorySlot = inventorySlotPlacement;

        inventorySlotPlacement.amount--;
        inventoryUI.objectMetaDataNeedsUpdating = true;
    }


    public void PlaceObject()
    {

        Physics.SyncTransforms();

        BoxCollider currentlySelectedBoxCollider = currentlySelected.GetComponent<BoxCollider>();

        Collider[] collisions = Physics.OverlapBox(currentlySelectedBoxCollider.transform.position + currentlySelectedBoxCollider.center, currentlySelectedBoxCollider.size / 2);


        for(int i = 0; i < collisions.Length; i++)
        {
            PlaceableObject collisionPlaceableObject = collisions[i].GetComponent<PlaceableObject>();

            if (collisionPlaceableObject != null && collisionPlaceableObject != currentlySelectedPlaceableObject) {
                return;
            }

        }

        if (doingHoverPlacement)
        {
            TrajectoryRecorder[] trajectoryRecorders = currentlySelected.GetComponentsInChildren<TrajectoryRecorder>();

            for(int i = 0; i < trajectoryRecorders.Length; i++)
            {
                objectTrajectoryTracker.playZoneEntityTrajectoryRecorders.Add(trajectoryRecorders[i]);
            }

            inventorySlotPlacement = null;

            doingHoverPlacement = false;

        }

        if (currentlySelectedPlaceableObject != null)
        {
            currentlySelectedPlaceableObject.ResetHighlight();
        }
        currentlySelected = null;
        currentlySelectedPlaceableObject = null;
    }

    public void DeleteObject(GameObject gameObjectToDestroy)
    {
        if (doingHoverPlacement)
        {
            doingHoverPlacement = false;
        }

        if (currentlySelectedPlaceableObject != null)
        {
            if (currentlySelectedPlaceableObject.sourceInventorySlot != null)
            {
                currentlySelectedPlaceableObject.sourceInventorySlot.amount++;
                inventoryUI.objectMetaDataNeedsUpdating = true;
            }
        }

        objectTrajectoryTracker.playZoneEntityTrajectoryRecorders.Remove(currentlySelected.GetComponentInChildren<TrajectoryRecorder>());

        GameObject.Destroy(currentlySelected);
        currentlySelected = null;
        inventorySlotPlacement = null;
    }


    private void Update()
    {
        if (timescale.timeState == Timescale.TimeState.Paused)
        {
            Vector3 mousePos = Input.mousePosition;

            mousePos.z = -Camera.main.transform.position.z;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);

            if (currentlySelected != null)
            {
                if (!inventoryOutOfBoundsZone.enabled && !robotOutOfBoundsZone.enabled)
                {
                    currentlySelected.transform.position = worldPosition;
                }
                else
                {
                    currentlySelected.transform.position = new Vector3(100f, 100f, 0f);
                }

                if (currentlySelectedPlaceableObject != null)
                {
                    currentlySelectedPlaceableObject.HighLightOutline();
                    currentlySelected.transform.Rotate(currentlySelectedPlaceableObject.rotationVector * 5f * Input.mouseScrollDelta.y, Space.Self);

                }

                Physics.SyncTransforms();
            }

            if (currentlySelected != null && Input.GetKey(KeyCode.Escape))
            {

                DeleteObject(currentlySelected);

            }
        }
    }
}




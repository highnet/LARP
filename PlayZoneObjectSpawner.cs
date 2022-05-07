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
        inventorySlotPlacement.amount--;
        inventoryUI.objectMetaDataNeedsUpdating = true;
    }


    public void PlaceObject()
    {
        if (doingHoverPlacement)
        {
            objectTrajectoryTracker.playZoneEntityTrajectoryRecorders.Add(currentlySelected.GetComponentInChildren<TrajectoryRecorder>());
            doingHoverPlacement = false;
        }
        currentlySelected = null;
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
                if (mousePos.x > 0 && mousePos.x < 750 && mousePos.y > 0 && mousePos.y < 530)
                {
                    currentlySelected.transform.position = worldPosition;
                }
                else
                {
                    currentlySelected.transform.position = new Vector3(100f, 100f, 0f);
                }
                Physics.SyncTransforms();
            }

            if (currentlySelected != null && doingHoverPlacement && Input.GetKey(KeyCode.Escape))
            {

                doingHoverPlacement = false;
                inventorySlotPlacement.amount++;
                inventoryUI.objectMetaDataNeedsUpdating = true;
                GameObject.Destroy(currentlySelected);
                currentlySelected = null;

            }
        }
    }
}




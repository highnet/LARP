using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<int> amounts;
    public List<GameObject> objects;
    private PlayZoneObjectSpawner playZoneObjectSpawner;
    public InventoryUI inventoryUI;

    private void Start()
    {
        playZoneObjectSpawner = GameObject.FindGameObjectWithTag("Play Zone Object Spawner").GetComponent<PlayZoneObjectSpawner>();
        inventoryUI = GameObject.FindGameObjectWithTag("Inventory UI").GetComponent<InventoryUI>();

        switch (SceneInformation.GetSceneName())
        {
            case "Developer Test Scene":

                objects.Add(playZoneObjectSpawner.playZoneObjectPrefabs[0]);
                amounts.Add(99);

                objects.Add(playZoneObjectSpawner.playZoneObjectPrefabs[1]);
                amounts.Add(99);

                objects.Add(playZoneObjectSpawner.playZoneObjectPrefabs[2]);
                amounts.Add(99);

                objects.Add(playZoneObjectSpawner.playZoneObjectPrefabs[3]);
                amounts.Add(99);

                objects.Add(playZoneObjectSpawner.playZoneObjectPrefabs[4]);
                amounts.Add(99);

                objects.Add(playZoneObjectSpawner.playZoneObjectPrefabs[5]);
                amounts.Add(99);

                objects.Add(playZoneObjectSpawner.playZoneObjectPrefabs[6]);
                amounts.Add(99);

                objects.Add(playZoneObjectSpawner.playZoneObjectPrefabs[7]);
                amounts.Add(99);

                objects.Add(playZoneObjectSpawner.playZoneObjectPrefabs[8]);
                amounts.Add(99);

                objects.Add(playZoneObjectSpawner.playZoneObjectPrefabs[9]);
                amounts.Add(99);

                break;
        }
        inventoryUI.UpdateInventoryObjects();


    }
}

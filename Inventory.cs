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

                objects.Add(playZoneObjectSpawner.playZoneObjectPrefabs[1]);
                amounts.Add(1);
                objects.Add(playZoneObjectSpawner.playZoneObjectPrefabs[3]);
                amounts.Add(2);
                objects.Add(playZoneObjectSpawner.playZoneObjectPrefabs[17]);
                amounts.Add(3);
                break;
        }
        inventoryUI.UpdateInventoryObjects();


    }
}

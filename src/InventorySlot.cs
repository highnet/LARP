using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public Image image;
    public Button button;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI amountText;

    public int amount;

    public GameObject @object;
    private PlayZoneObjectSpawner playZoneObjectSpawner;

    public Timescale timescale;


    private void Start()
    {
        playZoneObjectSpawner = GameObject.FindGameObjectWithTag("Play Zone Object Spawner").GetComponent<PlayZoneObjectSpawner>();
        timescale = GameObject.FindGameObjectWithTag("Timescale").GetComponent<Timescale>();

        image = GetComponent<Image>();
        button = GetComponent<Button>();
        nameText = GetComponentsInChildren<TextMeshProUGUI>()[0];
        amountText = GetComponentsInChildren<TextMeshProUGUI>()[1];

        button.onClick.AddListener(delegate { ActivatePlacement(); });
    }

    public void ActivatePlacement()
    {
        if (timescale.timeState == Timescale.TimeState.Paused && @object != null && amount > 0)
        {
            playZoneObjectSpawner.BeginHoverPlacementItem(@object,this);
        }
    }
}

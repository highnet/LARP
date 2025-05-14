using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseoverTooltip : MonoBehaviour
{

    public PlayLevelUIController playLevelUIController;
    public string mouseoverTooltipTitle;
    public string mouseoverTooltipDescription;

    // Start is called before the first frame update
    void Start()
    {
        playLevelUIController = GameObject.FindGameObjectWithTag("Play Level UI Controller").GetComponent<PlayLevelUIController>();

    }

    private void OnMouseEnter()
    {
        playLevelUIController.mouseoverTooltipTitle.text = mouseoverTooltipTitle;
        playLevelUIController.mouseOverTooltipDescription.text = mouseoverTooltipDescription;
    }

    private void OnMouseExit()
    {
        playLevelUIController.mouseoverTooltipTitle.text = "";
        playLevelUIController.mouseOverTooltipDescription.text = "";
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUIController : MonoBehaviour
{
    public GameObject playPanel;
    public UIPanelMovement playPanelMovement;
    public TextInputSimulator console;


    private void Start()
    {
        playPanelMovement = playPanel.GetComponent<UIPanelMovement>();
    }

    public void TogglePlayPanel()
    {

        if (playPanelMovement.onScreen)
        {
            playPanelMovement.MoveOffScreen();
        } else
        {
            playPanelMovement.MoveOnScreen();
        }

    }

    public void FakeConsoleTyping(string text)
    {
        console.FakeInputTyping(text);
    }

    public void ParseText()
    {
        console.ParseText();
    }
}

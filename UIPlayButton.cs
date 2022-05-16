using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPlayButton : MonoBehaviour
{
    private MainMenuUIController mainMenuUIController;
    private void Start()
    {
        mainMenuUIController = GameObject.FindGameObjectWithTag("Main Menu UI Controller").GetComponent<MainMenuUIController>();
    }


    public void SetConsoleText()
    {
        mainMenuUIController.FakeConsoleTyping("PLAY");
    }
}

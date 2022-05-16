using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TextInputSimulator : MonoBehaviour
{
    public TextMeshProUGUI displayText;
    public string displayString;
    public MainMenuUIController mainMenuUIController;
    public bool fakeTyping;
    public string fakeTypingString;



    private void Start()
    {
        StartCoroutine(BlinkOnOff());
        mainMenuUIController = GameObject.FindGameObjectWithTag("Main Menu UI Controller").GetComponent<MainMenuUIController>();

    }


    public IEnumerator BlinkOnOff()
    {

        while (true)
        {
            if (displayString.Equals("|") && !fakeTyping)
            {
                if (displayText.color == Color.white)
                {
                    displayText.color = Color.black;
                } else
                {
                    displayText.color = Color.white;
                }
            } else
            {
                displayText.color = Color.white;
            }
            yield return new WaitForSeconds(1f);
        }


    }
    private void Update()
    {
        displayText.text = displayString;


        if (fakeTyping) return;

        foreach (char c in Input.inputString)
        {
            if (c == '\b') // has backspace/delete been pressed?
            {
                if (displayString.Length != 0 && !displayString.Equals("|"))
                {
                    displayString = displayString.Substring(0, displayString.Length - 1);

                    if (displayString.Length == 0)
                    {
                        displayString = "|";
                    }
                }
            }
            else
            {
                if (displayString.Equals("|")){
                    displayString = "";
                }
                if ((c != '\n') && (c != '\r'))
                {
                    displayString += Char.ToUpper(c);
                    displayText.color = Color.white;


                }
            }
        }


        if (displayString.Length != 0 && Input.GetKey(KeyCode.Return))
        {
            ParseText();
        }

    }

    public void FakeInputTyping(string text)
    {

        if (fakeTyping) return;
        displayString = "";
        fakeTyping = true;
        fakeTypingString = text;

        StartCoroutine(FakeKeyboardPress());
    }

    public IEnumerator FakeKeyboardPress()
    {

        while (fakeTyping)
        {
            if (fakeTypingString.Length != 0)
            {
                yield return new WaitForSeconds(0.5f);
                displayString += fakeTypingString.Substring(0,1);
                fakeTypingString = fakeTypingString[1..];
            }
            else
            {
                yield return new WaitForSeconds(0.5f);
                ParseText();
                fakeTyping = false;
            }
        }

    }


    public void ParseText()
    {

        if (displayString == "PLAY")
        {
            mainMenuUIController.TogglePlayPanel();
        }
        else if (displayString == "OPTIONS")
        {

        } else if (displayString == "CREDITS")
        {

        }
        displayString = "|";
    }
}

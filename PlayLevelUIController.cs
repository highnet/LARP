using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayLevelUIController : MonoBehaviour
{

    public Image playAndPauseButtonImage;
    public Sprite playImage;
    public Sprite pauseImage;
    public TextMeshProUGUI playAndPauseText;
    public Timescale timescale;
    public TextMeshProUGUI rewindingText;
    public Rotate rewindingRotator;
    public TextMeshProUGUI mouseoverTooltipTitle;
    public TextMeshProUGUI mouseOverTooltipDescription;


    private void Start()
    {
        timescale = GameObject.FindGameObjectWithTag("Timescale").GetComponent<Timescale>();

    }

    public void UpdateRewindingElements()
    {
        if (timescale.timeState == Timescale.TimeState.Backtracking)
        {
            rewindingText.text = "Rewinding...";
            rewindingRotator.gameObject.SetActive(true);
            rewindingRotator.rotateSpeed = 200f;
        }
        else
        {
            rewindingText.text = "";
            rewindingRotator.rotateSpeed = 0f;
            rewindingRotator.gameObject.SetActive(false);

        }
    }


    public void TogglePlayAndPauseImage()
    {
        if (playAndPauseButtonImage.sprite == playImage)
        {
            playAndPauseButtonImage.sprite = pauseImage;
        } else
        {
            playAndPauseButtonImage.sprite = playImage;
        }
    }


    public void UpdatePlayAndPauseText()
    {
        if (timescale.timeState == Timescale.TimeState.Playing)
        {
            playAndPauseText.text = "REWIND";
        } else
        {
            playAndPauseText.text = "PLAY";
        }
    }

    public void ResetPlayAndPauseText()
    {
        playAndPauseText.text = "";
    }

}

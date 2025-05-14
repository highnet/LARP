using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class UIPanelMovement : MonoBehaviour
{

    public GameObject onScreenAnchor;
    public GameObject offScreenAnchor;
    public GameObject panel;
    public bool onScreen;


    private void Start()
    {
        panel = this.gameObject;
    }
    public void MoveOnScreen()
    {
        Debug.Log("Moving On Screen");
        panel.transform.DOMove(onScreenAnchor.transform.position, 2.0f);
        onScreen = true;

    }

    public void MoveOffScreen()
    {
        Debug.Log("Moving Off Screen");
        panel.transform.DOMove(offScreenAnchor.transform.position, 2.0f);
        onScreen = false;

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseButtonPressed : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool buttonPressed = false;
    public bool alreadyPressed = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!alreadyPressed)
        {
            print("button pressed!");
            alreadyPressed = true;
            buttonPressed = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        print("button released!");
        alreadyPressed = false;
        buttonPressed = false;
    }
}

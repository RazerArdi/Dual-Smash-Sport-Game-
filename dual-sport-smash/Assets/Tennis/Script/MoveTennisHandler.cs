using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveTennisHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isRight;

    public bool isButtonHoldRight;
    public bool isButtonHoldLeft;

    private void Start()
    {
        isButtonHoldRight = false;
        isButtonHoldLeft = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(isRight)
        {
            isButtonHoldRight = true;
        }
        else
        {
            isButtonHoldLeft = true;
        }
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (isRight)
        {
            isButtonHoldRight = false;
        }
        else
        {
            isButtonHoldLeft = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ThrowButtonHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public static ThrowButtonHandler Instance;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public bool isButtonDown;
    public bool isButtonUp;
    public bool isButtonHold;

    private void Start()
    {
        isButtonDown = false;
        isButtonUp = false;
        isButtonHold = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!isButtonDown)
        {
            isButtonDown = true;
        }

        isButtonHold = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isButtonHold = false;
        if (!isButtonUp)
        {
            isButtonUp = true;
        }
    }
}

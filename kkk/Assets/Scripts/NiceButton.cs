using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class NiceButton : MonoBehaviour,IPointerUpHandler,IPointerDownHandler
{
    public event Action Notify;

    private bool _isPointerDown;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        _isPointerDown = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isPointerDown = false;
    }

    public void Update()
    {
        if (_isPointerDown)
        {
            Notify?.Invoke();
        }
    }
}

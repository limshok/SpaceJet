using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionSetter : MonoBehaviour
{
    void Start()
    {
        var posOnScreen = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2,Screen.height,Camera.main.transform.position.z + transform.position.y));
        transform.position = new Vector3(posOnScreen.x,transform.position.y,posOnScreen.z + 100);
    }
}

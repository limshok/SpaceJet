using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float RotationSpeed;
    [SerializeField] private bool x;
    [SerializeField] private bool y;
    [SerializeField] private bool z;
    private int _intX;
    private int _intY;
    private int _intZ;
    private void Start()
    {
        _intX = x ? 1 : 0;
        _intY = y ? 1 : 0;
        _intZ = z ? 1 : 0;
    }

    void Update()
    {
        transform.Rotate(_intX*RotationSpeed*Time.deltaTime,_intY *RotationSpeed*Time.deltaTime,_intZ*RotationSpeed*Time.deltaTime);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GifSetUp : MonoBehaviour
{
    public GameObject ShipPrefab;
    public Transform root;

    void Start()
    {
        Instantiate(ShipPrefab, root);
    }
}

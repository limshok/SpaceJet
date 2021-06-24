using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailsAnimator : MonoBehaviour
{
    [SerializeField] private List<GameObject> trails;

    public void AnimateTrails(float scale)
    {
        foreach (var trail in trails)
        {
            trail.transform.localScale = new Vector3(scale,scale,scale);
        }
    }
}

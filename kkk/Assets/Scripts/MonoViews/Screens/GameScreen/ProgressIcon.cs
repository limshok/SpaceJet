using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public class ProgressIcon : MonoBehaviour
{
    [SerializeField] private Slider progressBar;
    [SerializeField] private TextMeshProUGUI progressCounter;
    
    public void SetProgress(int value,int targetValue)
    {
        progressBar.maxValue = targetValue;
        progressBar.value = value;
        progressCounter.text = (value + "/" + targetValue);
    }
}

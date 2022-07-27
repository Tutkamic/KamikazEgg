using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class SliderPowerScript : MonoBehaviour
{
    [SerializeField] Slider slider;
    float maxValue = 15;
    [SerializeField] TextMeshProUGUI textPower;

    private void OnEnable()
    {
        ObjectSelectionScript.SelectObjectBombPower += SetBombValue;
    }

    private void OnDisable()
    {
        ObjectSelectionScript.SelectObjectBombPower -= SetBombValue;
    }
    private void Start()
    {
        slider.maxValue = maxValue;
    }

    private void Update()
    {
        textPower.text = slider.value.ToString();
    }


    public void SetSliderValue(float x)
    {
        slider.value = x;
    }

    private void SetBombValue(float power)
    {
        slider.value = power;
    }

}

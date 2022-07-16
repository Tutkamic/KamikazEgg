using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderPowerScript : MonoBehaviour
{
    public Slider slider;
    public float maxValue;
    public TextMeshProUGUI textPower;

    private void Update()
    {
        textPower.text = slider.value.ToString();
    }
    private void Start()
    {
        slider.maxValue = maxValue;
    }

    public void SetSliderValue(float x)
    {
        slider.value = x;
    }

}

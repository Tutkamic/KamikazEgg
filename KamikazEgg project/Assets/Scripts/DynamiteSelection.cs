using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamiteSelection : MonoBehaviour, ISelectable
{
    [SerializeField] DynamiteExplosion dynamiteExplosion;
    [SerializeField] GameObject selectArea;
    private SliderPowerScript sliderScript;
    bool isSelected = false;

    private void Start()
    {
        sliderScript = FindObjectOfType<SliderPowerScript>();
    }

    private void Update()
    {
        SetPower();
    }

    public void Select()
    {
        selectArea.SetActive(true);
        sliderScript.SetSliderValue(dynamiteExplosion.dynamitePower);
        isSelected = true;
    }
    public void UnSelect()
    {
        selectArea.SetActive(false);
        isSelected = false;
    }

    void SetPower()
    {
        if (!isSelected)
            return;
        dynamiteExplosion.dynamitePower = sliderScript.slider.value;
    }
}

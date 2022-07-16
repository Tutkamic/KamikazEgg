using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSelection : MonoBehaviour, ISelectable
{
    [SerializeField] BombExplosion bombExplosion;
    [SerializeField] GameObject selectCircle;
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
        selectCircle.SetActive(true);
        sliderScript.SetSliderValue(bombExplosion.bombPower);
        isSelected = true;
    }
    public void UnSelect()
    {
        selectCircle.SetActive(false);
        isSelected = false;
    }

    void SetPower()
    {
        if (!isSelected)
            return;
        bombExplosion.bombPower = sliderScript.slider.value;
    }
}

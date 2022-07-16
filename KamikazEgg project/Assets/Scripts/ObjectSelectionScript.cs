using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelectionScript : MonoBehaviour, ISelectable
{
    [SerializeField] ObjectExplosionScript objExplosion;
    [SerializeField] GameObject selectImage;
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
        selectImage.SetActive(true);
        sliderScript.SetSliderValue(objExplosion.bombPower);
        isSelected = true;
    }
    public void UnSelect()
    {
        selectImage.SetActive(false);
        isSelected = false;
    }

    void SetPower()
    {
        if (!isSelected)
            return;
        objExplosion.bombPower = sliderScript.slider.value;
    }
}

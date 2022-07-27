using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUISlider : MonoBehaviour
{
    [SerializeField] Slider slider;

    private void OnEnable()
    {
        ObjectSelectionScript.SelectObject += SelectState;
        ButtonControllerScript.Ignite += IgniteState;
    }
    private void OnDisable()
    {
        ObjectSelectionScript.SelectObject -= SelectState;
        ButtonControllerScript.Ignite -= IgniteState;
    }

    private void IgniteState(bool isIgnite)
    {
        if (isIgnite) slider.gameObject.SetActive(false);
    }

    private void Start()
    {
        slider.gameObject.SetActive(false);
    }

    private void SelectState(bool isObjectSelected)
    {
        if (isObjectSelected) slider.gameObject.SetActive(true);
        else slider.gameObject.SetActive(false);
    }



}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class ButtonControllerScript : MonoBehaviour
{
    public static event Action<bool> Ignite;
    public static event Action<float> SetSliderValue;
    public static event Action<int> DragItem;

    [SerializeField] GameObject igniteButton;
    [SerializeField] GameObject restartButton;
    [SerializeField] Slider slider;


    public void IgniteStart()
    {
        igniteButton.SetActive(false);
        restartButton.SetActive(true);
        Ignite?.Invoke(true);
    }

    public void IgniteStop()
    {
        igniteButton.SetActive(true);
        restartButton.SetActive(false);
        Ignite?.Invoke(false);
    }


    public void SliderUP()
    {
        slider.value++;
        SetSliderValue?.Invoke(slider.value);
    }
    public void SliderDOWN()
    {
        if(slider.value > 1)
        slider.value--;

        SetSliderValue?.Invoke(slider.value);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void DragBomb()
    {
        DragItem?.Invoke(0);
    }
    public void DragDynamite()
    {
        DragItem?.Invoke(1);
    }
    public void DragGrenade()
    {
        DragItem?.Invoke(2);
    }
}

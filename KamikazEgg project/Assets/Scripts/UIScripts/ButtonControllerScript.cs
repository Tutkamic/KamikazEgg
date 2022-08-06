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
    public static event Action Pause;

    bool isFinished = false;

    [SerializeField] GameObject igniteButton;
    [SerializeField] GameObject restartButton;
    [SerializeField] Slider slider;

    private void OnEnable()
    {
        FinishAreaTrigger.FinishComplete += Finish;
    }
    private void OnDisable()
    {
        FinishAreaTrigger.FinishComplete -= Finish;
    }
    private void Start()
    {
        isFinished = false;
    }

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

    public void XButton()
    {
        if (isFinished) return;
        Time.timeScale = 0;
        Pause?.Invoke();
    }

    void Finish()
    {
        isFinished = true;
    }

}

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
    public static event Action ClickSound;

    bool isFinished = false;
    bool isFailed = false;

    [SerializeField] GameObject igniteButton;
    [SerializeField] GameObject restartButton;
    [SerializeField] Slider slider;

    private void OnEnable()
    {
        FinishAreaTrigger.FinishComplete += Finish;
        UIFailedWindow.Retry += IgniteRetry;
        EggFailed.Failed += Failed;
        EggFailed.FailedOff += FailedReset;
    }
    private void OnDisable()
    {
        FinishAreaTrigger.FinishComplete -= Finish;
        UIFailedWindow.Retry -= IgniteRetry;
        EggFailed.FailedOff -= FailedReset;
    }
    private void Start()
    {
        isFinished = false;
    }

    public void IgniteStart()
    {
        ClickSound?.Invoke();
        igniteButton.SetActive(false);
        restartButton.SetActive(true);
        Ignite?.Invoke(true);
    }

    public void IgniteStop()
    {
        ClickSound?.Invoke();
        igniteButton.SetActive(true);
        restartButton.SetActive(false);
        Ignite?.Invoke(false);
    }

    void IgniteRetry()
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
        if (slider.value > 1)
            slider.value--;

        SetSliderValue?.Invoke(slider.value);
    }

    public void XButton()
    {
        ClickSound?.Invoke();
        if (isFinished || isFailed) return;
        Time.timeScale = 0;
        Pause?.Invoke();
    }

    void Finish() => isFinished = true;

    void Failed() => isFailed = true;

    void FailedReset() => isFailed = false;

}

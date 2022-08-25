using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class UIFailedWindow : MonoBehaviour
{
    public static event Action ClickSound;
    public static event Action Retry;

    [SerializeField] GameObject failedWindow;

    private void OnEnable()
    {
        EggFailed.Failed += FailedON;
    }
    private void OnDisable()
    {
        EggFailed.Failed -= FailedON;
    }

    private void Start()
    {
        failedWindow.SetActive(false);
    }

    void FailedON()
    {
        failedWindow.SetActive(true);
        Time.timeScale = 0;
    }
    public void RetryButton()
    {
        ClickSound?.Invoke();
        Retry?.Invoke();
        failedWindow.SetActive(false);
        Time.timeScale = 1.0f;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EggFailed : MonoBehaviour
{
    public static event Action Failed;
    public static event Action FailedOff;

    string tagName = "Enemy";

    bool failed;

    private void OnEnable()
    {
        UIFailedWindow.Retry += ResetPosition;
    }

    private void OnDisable()
    {
        UIFailedWindow.Retry -= ResetPosition;
    }

    private void Start()
    {
        failed = false;
    }

    void Update()
    {
        EggFallCheck();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(tagName)) Failed?.Invoke();
    }

    private void EggFallCheck()
    {
        if ((Camera.main.WorldToScreenPoint(transform.position).y < -100) && !failed) 
        { 
            failed = true;
            Failed?.Invoke();
        }
    }

    void ResetPosition()
    {
        failed = false;
        FailedOff?.Invoke();
    }
}

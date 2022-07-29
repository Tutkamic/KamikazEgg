using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FinishAreaTrigger : MonoBehaviour
{
    public static event Action FinishComplete;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.TryGetComponent<EggMovement>(out var eggMovement)) {
            FinishComplete?.Invoke();
        }
    }
}

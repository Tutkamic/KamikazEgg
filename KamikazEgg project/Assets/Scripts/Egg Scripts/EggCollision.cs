using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EggCollision : MonoBehaviour
{
    public static event Action<GameObject> StarCollect;
    public static event Action SoundCollect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == null) return;
        if (collision.TryGetComponent(out ICollectable collectable)){
            collectable.Collect();
            StarCollect?.Invoke(collision.gameObject);
            SoundCollect?.Invoke();
        }
    }
}

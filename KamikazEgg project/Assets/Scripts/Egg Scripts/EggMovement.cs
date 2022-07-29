using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggMovement : MonoBehaviour
{

    Rigidbody2D rb;
    Vector3 eggStartPosition;

    private void OnEnable()
    {
        ButtonControllerScript.Ignite += IgniteState;
        FinishAreaTrigger.FinishComplete += EggFinish;
    }
    private void OnDisable()
    {
        ButtonControllerScript.Ignite -= IgniteState;
        FinishAreaTrigger.FinishComplete -= EggFinish;
    }


    void Start()
    {
        eggStartPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (rb.velocity.magnitude > 2f)
            transform.rotation = Quaternion.LookRotation(Vector3.forward, rb.velocity);
    }

    private void IgniteState(bool isIgnite)
    {
        if (isIgnite)
            return;
        else
        {
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            transform.position = eggStartPosition;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void EggFinish()
    {
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.isKinematic = true;
    }
}

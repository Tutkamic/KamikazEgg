using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPosition : MonoBehaviour, ILastPositionHandler
{
    Vector3 lastPosition;
    Quaternion lastRotation;

    Rigidbody2D rb;

    private void OnEnable()
    {
        ButtonControllerScript.Ignite += IgniteState;
    }
    private void OnDisable()
    {
        ButtonControllerScript.Ignite -= IgniteState;
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void LastPositionSave()
    {
        lastPosition = gameObject.transform.position;
        lastRotation = gameObject.transform.rotation;
    }

    public void ResetPosition()
    {
        gameObject.transform.position = lastPosition;
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        gameObject.transform.rotation = lastRotation;
    }

    void IgniteState(bool isIgnite)
    {
        if (isIgnite) return;
        ResetPosition();
    }

}

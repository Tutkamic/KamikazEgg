using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform aimObject;
    Vector3 v3start;
    Vector3 v3end;
    Vector3 v3target;
    Vector3 moveVector;
    float currentDistance;
    float distance;
    float treshold = 0.2f;

    void Start()
    {
        v3start = transform.position;
        v3end = aimObject.position;
        v3target = v3end;
        aimObject.gameObject.SetActive(false);
        distance = Math.Abs(Vector3.Distance(v3start, v3end));
    }


    void FixedUpdate()
    {
        MoveToObject(); 
    }

    private void MoveToObject()
    {
        moveVector = (v3target - transform.position).normalized;
        currentDistance = Math.Abs(Vector3.Distance(transform.position, v3target));
        if (currentDistance > distance / 8) transform.position += moveVector * speed * Time.fixedDeltaTime;
        else transform.position = Vector3.Lerp(transform.position, v3target, 2 * Time.fixedDeltaTime);


        if (v3target == v3end && currentDistance <= treshold) v3target = v3start;
        else if (currentDistance <= treshold) v3target = v3end;

    }
}

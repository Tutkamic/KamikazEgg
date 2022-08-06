using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleLineScript : MonoBehaviour
{
    ObjectExplosionScript objectExplosion;
    ObjectSelectionScript objectSelection;
    float scale;

    void Start()
    {
        objectExplosion = GetComponentInParent<ObjectExplosionScript>();
        objectSelection = GetComponentInParent<ObjectSelectionScript>();
    }

    // Update is called once per frame
    void Update()
    {
        CircleSettings();
    }

    void CircleSettings()
    {
        if (!objectSelection.isSelected) return;

        SetScale();
        RotateCircle();
    }

    private void RotateCircle()
    {
        transform.Rotate(new Vector3(0,0,-1) * 30 * Time.deltaTime);
    }

    void SetScale()
    {
        var power = objectExplosion.bombPower;
        float powerValue = Mathf.InverseLerp(1, 15, power);
        scale = Mathf.Lerp(3.5f, 8f, powerValue);
        transform.localScale = new Vector3(scale, scale, scale);
    }

}

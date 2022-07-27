using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleLineScript : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] Transform parentTransform;
    ObjectExplosionScript objectExplosion;
    ObjectSelectionScript objectSelection;
    Material mat;
    float radiusValue;
    float tiling;

    void Start()
    {
        objectExplosion = GetComponentInParent<ObjectExplosionScript>();
        objectSelection = GetComponentInParent<ObjectSelectionScript>();
        mat = lineRenderer.GetComponent<LineRenderer>().material;
        radiusValue = 1.8f;
        DrawCircle(100, radiusValue, parentTransform);
    }

    // Update is called once per frame
    void Update()
    {
        CircleSettings();
        DrawCircle(100, radiusValue, parentTransform);
    }

    void CircleSettings()
    {
        if (!objectSelection.isSelected) return;

        SetRadius();
    }

    void SetRadius()
    {
        var power = objectExplosion.bombPower;
        float powerValue = Mathf.InverseLerp(1, 15, power);
        radiusValue = Mathf.Lerp(1.8f, 3.5f, powerValue);

        TilingSet();

        void TilingSet()
        {
            tiling = Mathf.Lerp(18f, 30f, powerValue);
            mat.SetFloat("_Tiling", tiling);
        }
    }



    void DrawCircle(int steps, float radius, Transform transform)
    {
        if (!objectSelection.isSelected) return;

        lineRenderer.positionCount = steps;

        for (int currentStep = 0; currentStep < steps; currentStep++)
        {
            float obwodProgress = (float)currentStep / steps;
            float currentRadian = obwodProgress * 2 * Mathf.PI;

            float xScaled = Mathf.Cos(currentRadian);
            float yScaled = Mathf.Sin(currentRadian);

            float x = transform.position.x + xScaled * radius;
            float y = transform.position.y + yScaled * radius;

            Vector3 currentPosition = new Vector3(x, y, 0);

            lineRenderer.SetPosition(currentStep, currentPosition);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class ObjectExplosionScript : MonoBehaviour, IExplosible
{
    [SerializeField] GameObject boomImage;
    [SerializeField] GameObject selectImage;
    [SerializeField] GameObject onFire;
    [SerializeField] GameObject EfectArea;
    [SerializeField] ObjectSelectionScript objectSelectionScript;
    Rigidbody2D rb;


    public float bombPower { get; private set; }

    private bool isExploded = false;

    public static event Action<GameObject> Explode;

    private void OnEnable()
    {
        ButtonControllerScript.Ignite += IgniteState;
        ButtonControllerScript.SetSliderValue += SetPower;
    }
    private void OnDisable()
    {
        ButtonControllerScript.Ignite -= IgniteState;
        ButtonControllerScript.SetSliderValue -= SetPower;
    }


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        onFire.SetActive(false);
        bombPower = 1;
    }

    public void Boom()
    {
        if (isExploded)
            return;
        isExploded = true;


        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0f;
        rb.isKinematic = true;
        boomImage.SetActive(true);
        boomImage.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        StartCoroutine(BoomCountdown());
        Explode?.Invoke(gameObject);
    }


    IEnumerator BoomCountdown()
    {
        yield return new WaitForSeconds(0.5f);
        EfectArea.SetActive(false);
        onFire.SetActive(false);
        boomImage.SetActive(false);
        gameObject.SetActive(false);
        isExploded = false;
    }

    public void IgniteState(bool isIgnite)
    {
        if (isIgnite)
        {
            objectSelectionScript.UnSelect();
            boomImage.SetActive(false);
            onFire.SetActive(true);
            selectImage.SetActive(false);
            EfectArea.SetActive(true);
            isExploded = false;
        }
        else
        {
            StopAllCoroutines();
            onFire.SetActive(false);
            EfectArea.SetActive(false);
        }
    }

    void SetPower(float power)
    {
        if (!objectSelectionScript.isSelected)
            return;
        bombPower = power;
    }

    public void ResetPower()
    {
        onFire.SetActive(false);
        EfectArea.SetActive(false);
        bombPower = 1;
    }

}

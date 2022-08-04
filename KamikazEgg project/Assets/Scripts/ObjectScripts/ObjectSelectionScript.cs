using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSelectionScript : MonoBehaviour, ISelectable
{
    [SerializeField] ObjectExplosionScript objExplosion;
    [SerializeField] GameObject selectImage;
    [SerializeField] GameObject circleExplosionSim;
    public bool isSelected { get; private set; }
    float selectedBombPower;

    public static event Action<bool> SelectObject;
    public static event Action<float> SelectObjectBombPower;



    private void Start()
    {
        isSelected = false;
    }
    public void Select()
    {
        selectImage.SetActive(true);
        circleExplosionSim.SetActive(true);
        SelectObject?.Invoke(true);
        ReadBombPower();
        isSelected = true;
    }
    public void UnSelect()
    {
        selectImage.SetActive(false);
        circleExplosionSim.SetActive(false);
        SelectObject?.Invoke(false);
        isSelected = false;
    }

    private void ReadBombPower()
    {
        selectedBombPower = objExplosion.bombPower;
        SelectObjectBombPower?.Invoke(selectedBombPower);
    }

}

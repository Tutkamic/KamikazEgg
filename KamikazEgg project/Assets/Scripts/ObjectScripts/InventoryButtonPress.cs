using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class InventoryButtonPress : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] int itemIndex;
    public static event Action<int> InventorySlotSelect;

    bool isIgnite = false;

    private void OnEnable()
    {
        ButtonControllerScript.Ignite += IsIgnite;
    }
    private void OnDisable()
    {
        ButtonControllerScript.Ignite -= IsIgnite;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (LevelSetupScript.Instance.slotAmount[itemIndex] == 0 || isIgnite) return;
        InventorySlotSelect?.Invoke(itemIndex);
    }

    void IsIgnite(bool ignite) => isIgnite = ignite;
}

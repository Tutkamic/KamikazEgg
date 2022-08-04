using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;

public class InventoryButtonPress : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] int itemIndex;
    public static event Action<int, bool> InventorySlotSelect;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (LevelSetupScript.Instance.slotAmount[itemIndex] == 0) return;
        InventorySlotSelect?.Invoke(itemIndex, true);
    }

}

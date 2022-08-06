using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UISlotTextScript : MonoBehaviour
{
    [SerializeField] int SlotIndex;
    int amount;
    TextMeshProUGUI text;
    IInventoryImageHandler inventoryImageHandler;

    private void OnEnable()
    {
        InstantiateExplosives.ItemAmountUpdate += ItemAmount;
    }
    private void OnDisable()
    {
        InstantiateExplosives.ItemAmountUpdate -= ItemAmount;
    }

    // Start is called before the first frame update
    void Start()
    {
        inventoryImageHandler = GetComponentInParent<IInventoryImageHandler>();
        text = GetComponent<TextMeshProUGUI>();
        amount = LevelSetupScript.Instance.slotAmount[SlotIndex]; 
        text.text = amount.ToString();
    }


    void ItemAmount()
    {
        amount = LevelSetupScript.Instance.slotAmount[SlotIndex];
        inventoryImageHandler.ImageChange(amount);
        text.text = amount.ToString();
    }
}

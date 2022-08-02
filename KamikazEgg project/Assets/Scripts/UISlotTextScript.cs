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

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        amount = LevelSetupScript.Instance.slotAmount[SlotIndex]; 
        text.text = amount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

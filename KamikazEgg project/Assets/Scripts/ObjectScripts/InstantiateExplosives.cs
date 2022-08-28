using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InstantiateExplosives : MonoBehaviour
{
    public static event Action<GameObject> DraggedInventoryItem;
    public static event Action ItemAmountUpdate;

    [SerializeField] GameObject[] explosivesInstance;
    int[] amountSlot = new int[3];
    Transform spawnPosition;
    List<List<GameObject>> spawnedExplosive = new List<List<GameObject>>();

    private void OnEnable()
    {
        DragFromInventory.ShowInventoryItem += ShowItem;
        DragFromInventory.HideInventoryItem += HideItem;
        ObjectFallDown.ItemFallDown += HideItem;
    }

    private void OnDisable()
    {
        DragFromInventory.ShowInventoryItem -= ShowItem;
        DragFromInventory.HideInventoryItem -= HideItem;
        ObjectFallDown.ItemFallDown -= HideItem;
    }

    void Start()
    {
        spawnPosition = gameObject.transform;
        spawnedExplosive.Add(new List<GameObject>());
        spawnedExplosive.Add(new List<GameObject>());
        spawnedExplosive.Add(new List<GameObject>());
        for (int i = 0; i < 3; i++)
        {
            amountSlot[i] = LevelSetupScript.Instance.slotAmount[i];
            for (int j = 0; j < amountSlot[i]; j++)
            {
                var explosive = Instantiate(explosivesInstance[i], spawnPosition);
                spawnedExplosive[i].Add(explosive);
                explosive.SetActive(false);
            }

        }

    }

    public void ShowItem(int itemIndex)
    {
        if (amountSlot[itemIndex] == 0) return;
        var item = spawnedExplosive[itemIndex][spawnedExplosive[itemIndex].Count - 1];
        item.SetActive(true);
        DraggedInventoryItem?.Invoke(item);
        spawnedExplosive[itemIndex].RemoveAt(spawnedExplosive[itemIndex].Count - 1);
        amountSlot[itemIndex]--;
        LevelSetupScript.Instance.slotAmount[itemIndex] = amountSlot[itemIndex];
        ItemAmountUpdate?.Invoke();
    }

    public void HideItem(int itemIndex, GameObject item)
    {
        spawnedExplosive[itemIndex].Add(item);
        amountSlot[itemIndex]++;
        LevelSetupScript.Instance.slotAmount[itemIndex] = amountSlot[itemIndex];
        ItemAmountUpdate?.Invoke();
    }
}

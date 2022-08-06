using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryIcon : MonoBehaviour, IInventoryImageHandler
{
    [SerializeField] Sprite activeImage;
    [SerializeField] Sprite unactiveImage;
    Image image;
    [SerializeField] int itemIndex;

    void Start()
    {
        image = GetComponent<Image>();
        int itemAmount = LevelSetupScript.Instance.slotAmount[itemIndex];
        if(itemAmount > 0) image.sprite = activeImage;
    }

    public void ImageChange(int amount)
    {
        if(amount == 0) image.sprite = unactiveImage;
        else image.sprite = activeImage;
    }
}

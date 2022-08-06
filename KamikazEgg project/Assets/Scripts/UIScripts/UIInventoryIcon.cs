using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryIcon : MonoBehaviour, IInventoryImageHandler
{
    [SerializeField] Sprite activeImage;
    [SerializeField] Sprite unactiveImage;
    Image image;

    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ImageChange(int amount)
    {
        if(amount == 0) image.sprite = unactiveImage;
        else image.sprite = activeImage;
    }
}

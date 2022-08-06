using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UILevelButton : MonoBehaviour, IButtonHandler
{
    [SerializeField] TextMeshProUGUI buttonText;
    [SerializeField] Image lockImage;
    [SerializeField] Image[] star;
    [SerializeField] Sprite[] sprites;

    void Start()
    {
        buttonText.gameObject.SetActive(false);
        lockImage.gameObject.SetActive(true);
    }

    public void ButtonChange(bool isAvailable, int levelScore, int levelIndex)
    {
        buttonText.text = levelIndex.ToString();
        if (isAvailable)
        {
            buttonText.gameObject.SetActive(true);
            lockImage.gameObject.SetActive(false);
        }

        for (int i = 0; i < levelScore; i++) star[i].sprite = sprites[1];
    }
}

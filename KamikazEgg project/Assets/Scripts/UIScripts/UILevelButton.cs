using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UILevelButton : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI buttonText;
    [SerializeField] Image lockImage;
    [SerializeField] Image[] star;
    [SerializeField] Sprite[] sprites;
    [SerializeField] GameObject stars;

    LevelInfo levelInfoScript;
    int levelIndex;
    void Start()
    {
        levelInfoScript = GetComponent<LevelInfo>();
        levelIndex = levelInfoScript.levelIndex;
        bool isAvailable = LevelSetupScript.Instance.levelAvilable[levelIndex - 1];
        int levelScore = LevelSetupScript.Instance.levelScore[levelIndex - 1];

        buttonText.text = levelIndex.ToString();

        if (isAvailable)
        {
            buttonText.gameObject.SetActive(true);
            lockImage.gameObject.SetActive(false);
            stars.SetActive(true);
        } else
        {
            stars.SetActive(false);
            buttonText.gameObject.SetActive(false);
            lockImage.gameObject.SetActive(true);
        }

        for (int i = 0; i < levelScore; i++) star[i].sprite = sprites[1];
    }

}

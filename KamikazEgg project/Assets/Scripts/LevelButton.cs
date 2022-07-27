using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    [SerializeField] int level;
    [SerializeField] TextMeshProUGUI buttonText;
    [SerializeField] Image lockImage;
    [SerializeField] Image[] star;
    [SerializeField] Sprite[] sprites;
    [SerializeField] bool isAvailable;
    [SerializeField] int starScore = 0;

    void Start()
    {
        buttonText.text = level.ToString();
        buttonText.gameObject.SetActive(false);
        lockImage.gameObject.SetActive(true);
    }


    void Update()
    {
        if (isAvailable)
        {
            buttonText.gameObject.SetActive(true);
            lockImage.gameObject.SetActive(false);
        }
    }

    public void PlayLevel()
    {
        SceneManager.LoadScene(2);
    }
}

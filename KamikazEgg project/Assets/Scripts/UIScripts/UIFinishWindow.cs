using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIFinishWindow : MonoBehaviour
{
    [SerializeField] GameObject finishWindow;

    [SerializeField] Image[] stars;
    [SerializeField] Sprite starSpriteON;
    [SerializeField] Sprite starSpriteOFF;
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI scoreText;

    private void OnEnable()
    {
        ScoreManager.FinishSetup += Finish; 
    }
    private void OnDisable()
    {
        ScoreManager.FinishSetup -= Finish;
    }

    private void Start()
    {
        for (int i = 0; i < 3; i++) stars[i].sprite = starSpriteOFF;
        finishWindow.SetActive(false);
    }

    void Finish(int currentScore)
    {
        finishWindow.SetActive(true);
        int currentLevelIndex = LevelSetupScript.Instance.currentLevelIndex - 1;
        int totalScore = LevelSetupScript.Instance.totalScore;

        levelText.text = "Level " + (currentLevelIndex + 1).ToString();
        for (int i = 0; i < currentScore; i++) stars[i].sprite = starSpriteON;
        scoreText.text = totalScore.ToString();
    }
}

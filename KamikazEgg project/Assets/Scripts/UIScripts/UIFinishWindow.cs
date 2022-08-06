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
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI scoreText;

    private void OnEnable()
    {
        FinishAreaTrigger.FinishComplete += Finish; 
    }
    private void OnDisable()
    {
        FinishAreaTrigger.FinishComplete -= Finish;
    }

    private void Start()
    {
        finishWindow.SetActive(false);
    }

    void Finish()
    {
        finishWindow.SetActive(true);

        int currentLevelIndex = LevelSetupScript.Instance.currentLevelIndex - 1;
        int levelScore = LevelSetupScript.Instance.levelScore[currentLevelIndex];
        int totalScore = LevelSetupScript.Instance.totalScore;

        levelText.text = "Level " + (currentLevelIndex + 1).ToString();
        for (int i = 0; i < levelScore; i++) stars[i].sprite = starSpriteON;
        scoreText.text = totalScore.ToString();
    }
}

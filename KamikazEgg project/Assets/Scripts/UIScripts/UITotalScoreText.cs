using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UITotalScoreText : MonoBehaviour
{
    TextMeshProUGUI text;
    int totalScore;
    void Start()
    {
        totalScore = LevelSetupScript.Instance.totalScore;
        text = GetComponent<TextMeshProUGUI>();
        text.text = "TOTAL SCORE : " + totalScore;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuSceneLoad : MonoBehaviour
{
    // Start is called before the first frame update
    public void StartButton()
    {
        LevelSetupScript.Instance.levelAvilable[0] = true;
        SceneManager.LoadScene(1);
    }
    public void HowToPlayButton()
    {
        SceneManager.LoadScene(1);
    }
}

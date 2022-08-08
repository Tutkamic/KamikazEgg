using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class ButtonBackExit : MonoBehaviour
{
    public static event Action SoundClick;

    public void BackButton()
    {
        SoundClick?.Invoke();
        SceneManager.LoadScene(0);
    }

    public void ExitButton()
    {
        SoundClick?.Invoke();
        Application.Quit();
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControllerScript : MonoBehaviour
{
    public DynamiteExplosion dynamiteExplosion;
    public BombExplosion bombExplosion;
    public void BombButton()
    {
        bombExplosion.BombExplode();
    }

    public void DynamiteButton()
    {
        dynamiteExplosion.DynamiteExplode();
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(0);
    }
}

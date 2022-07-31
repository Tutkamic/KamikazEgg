using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    List<GameObject> starCollected = new List<GameObject>();
    bool isIgnite = false;
    private void OnEnable()
    {
        EggCollision.StarCollect += OnStarCollect;
        ButtonControllerScript.Ignite += StarReset;
    }
    private void OnDisable()
    {
        EggCollision.StarCollect -= OnStarCollect;
        ButtonControllerScript.Ignite -= StarReset;
    }


    void OnStarCollect(GameObject star)
    {
        starCollected.Add(star);
    }

    void StarReset(bool isIgnite)
    {
        if (isIgnite) return;
        foreach (var item in starCollected) item.gameObject.SetActive(true);
        starCollected.Clear();
    }
}

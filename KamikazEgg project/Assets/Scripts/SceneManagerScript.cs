using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagerScript : MonoBehaviour
{
    public GameObject[] explosives;
    public bool isIgnite = false;
    public bool isObjectSelected = false;

    public List<GameObject> destroyedObj = new List<GameObject>();

    public void IgniteStart()
    {
        explosives = GameObject.FindGameObjectsWithTag("Explosive");
        foreach(GameObject go in explosives)
        {
            IExplosible explosible = go.GetComponent<IExplosible>();
            explosible.Ignite();
        }
        isIgnite = true;
        isObjectSelected = false;
    }

    public void IgniteStop()
    {
        explosives = GameObject.FindGameObjectsWithTag("Explosive");
        foreach (GameObject go in explosives)
        {
            IExplosible explosible = go.GetComponent<IExplosible>();
            explosible.UnIgnite();
        }
        isIgnite = false;

        Restart();
    }

    public void Restart()
    {
        foreach (GameObject go in destroyedObj)
        {
            go.SetActive(true);
        }
        destroyedObj.Clear();
    }
}

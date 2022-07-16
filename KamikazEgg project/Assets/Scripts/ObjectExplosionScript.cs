using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectExplosionScript : MonoBehaviour, IExplosible
{
    private SceneManagerScript sceneManagerScript;
    private GameObject egg;
    public GameObject boomImage;
    public GameObject selectImage;
    public GameObject onFire;
    private EggExplosion eggExplosion;

    public float bombPower;
    public float bombDistanceFactor;

    public Vector2 bombEggVector;

    private void Update()
    {
        DistanceFactor();
    }

    private void Start()
    {
        sceneManagerScript = FindObjectOfType<SceneManagerScript>();
        onFire.SetActive(false);
        egg = GameObject.FindGameObjectWithTag("Egg");
        eggExplosion = egg.gameObject.GetComponent<EggExplosion>();
        bombPower = 1;
        bombDistanceFactor = 0;
    }

    public void Boom()
    {
        sceneManagerScript.destroyedObj.Add(gameObject);
        bombEggVector = (egg.transform.position - transform.position).normalized;
        boomImage.SetActive(true);
        boomImage.gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        eggExplosion.Boom(bombEggVector, bombPower, bombDistanceFactor);

        StartCoroutine(BoomCountdown());
    }

    void DistanceFactor()
    {
        float distance = Vector3.Distance(egg.transform.position, transform.position);
        bombDistanceFactor = Mathf.InverseLerp(4.0f, 2f, distance);
    }

    IEnumerator BoomCountdown()
    {
        yield return new WaitForSeconds(0.5f);
        onFire.SetActive(false);
        boomImage.SetActive(false);
        gameObject.SetActive(false);
    }

    public void Ignite()
    {
        boomImage.SetActive(false);
        onFire.SetActive(true);
        selectImage.SetActive(false);
    }

    public void UnIgnite()
    {
        StopAllCoroutines();
        onFire.SetActive(false);
    }
}

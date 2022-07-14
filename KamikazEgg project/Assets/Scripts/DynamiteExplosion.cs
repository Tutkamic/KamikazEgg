using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamiteExplosion : MonoBehaviour
{
    public GameObject egg;
    public GameObject boomImage;
    private EggExplosion eggExplosion;

    public float dynamitePower;
    public float dynamiteDistanceFactor;

    public Vector2 dynamiteEggVector;

    private void Start()
    {
        eggExplosion = egg.gameObject.GetComponent<EggExplosion>();
    }

    public void DynamiteExplode()
    {
        dynamiteEggVector = (egg.transform.position - this.transform.position).normalized;
        boomImage.SetActive(true);

        eggExplosion.Boom(dynamiteEggVector, dynamitePower, dynamiteDistanceFactor);

        StartCoroutine(BoomCountdown());
    }

    IEnumerator BoomCountdown()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }

}

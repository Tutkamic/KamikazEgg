using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExplosion : MonoBehaviour
{
    public GameObject egg;
    public GameObject boomImage;
    private EggExplosion eggExplosion;

    public float bombPower;
    public float bombDistanceFactor;

    public Vector2 bombEggVector;

    private void Start()
    {
        eggExplosion = egg.gameObject.GetComponent<EggExplosion>();
    }
    public void BombExplode()
    {
        bombEggVector = (egg.transform.position - this.transform.position).normalized;
        boomImage.SetActive(true);

        eggExplosion.Boom(bombEggVector, bombPower, bombDistanceFactor);

        StartCoroutine(BoomCountdown());
    }

    IEnumerator BoomCountdown()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }


}

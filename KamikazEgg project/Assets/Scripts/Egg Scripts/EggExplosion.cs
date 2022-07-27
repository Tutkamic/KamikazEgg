using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggExplosion : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 bombEggVector;
    float bombDistanceFactor;


    private void OnEnable()
    {
        ObjectExplosionScript.Explode += Boom;
    }
    private void OnDisable()
    {
        ObjectExplosionScript.Explode -= Boom;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    public void Boom(GameObject bomb)
    {
        float power = bomb.gameObject.GetComponent<ObjectExplosionScript>().bombPower;
        float distance = Vector3.Distance(transform.position, bomb.transform.position);
        bombDistanceFactor = Mathf.InverseLerp(4.0f, 2f, distance);
        bombEggVector = (transform.position - bomb.transform.position).normalized;
        rb.AddForce(bombEggVector * power * bombDistanceFactor, ForceMode2D.Impulse);
    }

}

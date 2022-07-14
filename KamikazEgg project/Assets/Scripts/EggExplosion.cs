using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggExplosion : MonoBehaviour
{
    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Boom(Vector2 vector, float power, float distanceFactor)
    {
        rb.AddForce(vector * power * distanceFactor, ForceMode2D.Impulse);
    }

}

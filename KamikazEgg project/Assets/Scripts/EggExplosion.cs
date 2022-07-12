using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggExplosion : MonoBehaviour
{
    public Vector2 bombEggVector;
    public GameObject bomb;
    public float bombPower = 10f;
    float bombEggAngle;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (rb.velocity.magnitude > 2f)
        transform.rotation = Quaternion.LookRotation(Vector3.forward, rb.velocity);
    }

    public void Boom()
    {
            bombEggVector = (this.transform.position - bomb.transform.position).normalized;
            this.GetComponent<Rigidbody2D>().AddForce(bombEggVector * bombPower, ForceMode2D.Impulse);
    }
}

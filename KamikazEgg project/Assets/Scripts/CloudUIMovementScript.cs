using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudUIMovementScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position -= new Vector3(50f, 0f, 0f) * Time.deltaTime;

        if (transform.position.x < -700f)
        {

            transform.position = new Vector3(3300f, transform.position.y, transform.position.z);
        }
    }
}

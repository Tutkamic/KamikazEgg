using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControllerScript : MonoBehaviour
{
    [SerializeField] SceneManagerScript sceneManagerScript;
    [SerializeField] GameObject egg;
    Rigidbody2D rb;

    Vector3 eggStartPosition;

    private void Start()
    {
        eggStartPosition = egg.transform.position;
        rb = egg.GetComponent<Rigidbody2D>();
    }
    public void RestartButton()
    {
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
        egg.transform.position = eggStartPosition;
        egg.transform.rotation = Quaternion.Euler(0, 0, 0);

        sceneManagerScript.IgniteStop();
    }

    public void IgniteButton()
    {
        sceneManagerScript.IgniteStart();
    }
}

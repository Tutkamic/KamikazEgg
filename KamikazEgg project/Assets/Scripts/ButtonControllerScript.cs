using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonControllerScript : MonoBehaviour
{
    [SerializeField] SceneManagerScript sceneManagerScript;
    [SerializeField] GameObject egg;
    [SerializeField] GameObject igniteButton;
    [SerializeField] GameObject restartButton;
    [SerializeField] Slider slider;
    Rigidbody2D rb;

    Vector3 eggStartPosition;

    private void Start()
    {
        eggStartPosition = egg.transform.position;
        rb = egg.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (sceneManagerScript.isIgnite)
        {
            igniteButton.SetActive(false);
            restartButton.SetActive(true);
        }
        else
        {
            igniteButton.SetActive(true);
            restartButton.SetActive(false);
        }
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

    public void SliderUP()
    {
        slider.value++;
    }
    public void SliderDOWN()
    {
        slider.value--;
    }
}

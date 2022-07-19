using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUISlider : MonoBehaviour
{
    [SerializeField] SceneManagerScript sceneManagerScript;
    [SerializeField] Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SliderOnOff();
    }

    void SliderOnOff()
    {
        if(sceneManagerScript.isObjectSelected == false)
            slider.gameObject.SetActive(false);
        else
            slider.gameObject.SetActive(true);
    }
}

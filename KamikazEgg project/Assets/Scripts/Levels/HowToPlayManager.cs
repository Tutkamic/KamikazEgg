using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class HowToPlayManager : MonoBehaviour
{
    public static event Action ClickSound;

    [SerializeField] GameObject finishWindow;
    [SerializeField] GameObject Etap1;
    [SerializeField] GameObject Etap2;
    [SerializeField] GameObject Etap3;
    [SerializeField] GameObject Etap4;
    [SerializeField] GameObject Etap1Object;
    bool isEtap1End = false;
    bool isEtap2End = false;
    bool isEtap3End = false;
    private void OnEnable()
    {
        FinishAreaTrigger.FinishComplete += Finish;
        DragFromInventory.PutItemDown += StartEtap2;
        ButtonControllerScript.Ignite += StartEtap3;
        ObjectExplosionScript.Explode += StartEtap4;
        ButtonControllerScript.Ignite += EndEtap4;
    }
    private void OnDisable()
    {
        FinishAreaTrigger.FinishComplete -= Finish;
        DragFromInventory.PutItemDown -= StartEtap2;
        ButtonControllerScript.Ignite -= StartEtap3;
        ObjectExplosionScript.Explode -= StartEtap4;
        ButtonControllerScript.Ignite -= EndEtap4;
    }

    private void Start()
    {
        finishWindow.SetActive(false);
        Etap1.SetActive(true);
        Etap1Object.SetActive(true);
        Etap2.SetActive(false);
        Etap3.SetActive(false);
        Etap4.SetActive(false);
    }
    void Finish()
    {
        finishWindow.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void Replay()
    {
        ClickSound?.Invoke();
        Time.timeScale = 1.0f;
        LevelSetupScript.Instance.slotAmount[0] = 1;
        LevelSetupScript.Instance.slotAmount[1] = 0;
        LevelSetupScript.Instance.slotAmount[2] = 0;
        SceneManager.LoadScene(3);
    }
    
    public void Home()
    {
        ClickSound?.Invoke();
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }
    public void ResumeButton()
    {
        ClickSound?.Invoke();
        finishWindow.SetActive(false);
        Time.timeScale = 1.0f;
    }

    void StartEtap2()
    {
        if (isEtap1End) return;
        Etap1.SetActive(false);
        Etap1Object.SetActive(false);
        Etap2.SetActive(true);
        isEtap1End = true;
    }
    void StartEtap3(bool isIgnite)
    {
        if (!isEtap1End) return;
        if (isEtap2End) return;
        Etap2.SetActive(false);
        Etap3.SetActive(true);
        isEtap2End = isIgnite;
    }
    void StartEtap4(GameObject bomb)
    {
        if (isEtap3End) return;
        Etap3.SetActive(false);
        Etap4.SetActive(true);
        isEtap3End = true;
    }
    void EndEtap4(bool isIgnite)
    {
        if (isIgnite) return;
        Etap4.SetActive(false);
    }

}

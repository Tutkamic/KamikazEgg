using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayManager : MonoBehaviour
{
    [SerializeField] AudioSource collect;
    [SerializeField] AudioSource boom;
    [SerializeField] AudioSource finish;
    [SerializeField] AudioSource click;

    public static SoundPlayManager Instance { get; private set; }

    private void OnEnable()
    {
        EggCollision.SoundCollect += Collect;
        ObjectExplosionScript.ExplodeSound += Boom;
        FinishAreaTrigger.FinishComplete += Finish;
        MainMenuSceneLoad.ClickSound += Click;
        ButtonBackExit.SoundClick += Click;
        LevelInfo.SoundClick += Click;
        ButtonControllerScript.ClickSound += Click;
        UIPauseWindow.ClickSound += Click;
        NextButton.ClickSound += Click;
        HowToPlayManager.ClickSound += Click;
    }
    private void OnDisable()
    {
        EggCollision.SoundCollect -= Collect;
        ObjectExplosionScript.ExplodeSound -= Boom;
        FinishAreaTrigger.FinishComplete -= Finish;
        MainMenuSceneLoad.ClickSound -= Click;
        ButtonBackExit.SoundClick -= Click;
        LevelInfo.SoundClick -= Click;
        ButtonControllerScript.ClickSound -= Click;
        UIPauseWindow.ClickSound -= Click;
        NextButton.ClickSound -= Click;
        HowToPlayManager.ClickSound -= Click;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    void Collect()
    {
        collect.Play();
    }
    void Boom()
    {
        boom.Play();
    }
    void Finish()
    {
        finish.Play();
    }
    void Click()
    {
        click.Play();
    }

}

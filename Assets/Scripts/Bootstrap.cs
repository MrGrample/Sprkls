using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField]
    GameObject panelManager;
    [SerializeField]
    GameObject gameManage;
    [SerializeField]
    GameObject storyTeller;
    [SerializeField]
    GameObject soundManager;

    private void Awake()
    {
        if (gameManager.instance == null)
        {
            Instantiate(gameManage);
        }

        if (PanelManager.instance == null)
        {
            Instantiate(panelManager);
        }

        if (StoryTeller.instance == null)
        {
            Instantiate(storyTeller);
        }

        if (SoundManager.Singleton == null)
        {
            Instantiate(soundManager);
        }
    }
}

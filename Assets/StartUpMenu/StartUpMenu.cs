using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartUpMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject background;
    [SerializeField]
    private GameObject glow;
    [SerializeField]
    private GameObject game;

    public void StartGame()
    {
        if (Cursor.visible)
        {
            glow.SetActive(false);
            background.GetComponent<Animator>().SetTrigger("Fade");
            gameManager.instance.ChangeCursor(2);
        }
    }

    private void OnEnable()
    {
        background.GetComponent<Fading>().FadeIn();    
    }

    public void AnimationOver()
    {
        gameManager.instance.ChangeCursor(0);
        game.SetActive(true);
        StoryTeller.instance.ActivateStory();
        gameObject.SetActive(false);
    }

    public void FadeInOver()
    {
        gameManager.instance.ActivateCursor();
    }

    private void OnMouseDown()
    {
        gameManager.instance.ChangeCursor(1);
    }

    private void OnMouseUp()
    {
        gameManager.instance.ChangeCursor(0);
    }
}

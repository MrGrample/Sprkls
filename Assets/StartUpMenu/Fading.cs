using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fading : MonoBehaviour
{
    public UnityEvent fadeOver;
    public UnityEvent fadeInOver;

    private void Start()
    {
        if (fadeOver == null)
            fadeOver = new UnityEvent();
        if (fadeInOver == null)
            fadeInOver = new UnityEvent();
    }

    public void FadeIn()
    {
        GetComponent<Animator>().SetTrigger("FadeIn");
    }

    private void FadeOver()
    {
        fadeOver.Invoke();   
    }

    private void FadeInOver()
    {
        fadeInOver.Invoke();
    }
}

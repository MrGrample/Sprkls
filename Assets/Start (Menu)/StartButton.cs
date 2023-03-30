using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{

    [SerializeField]
    private Sprite sprite;
    [SerializeField]
    private Sprite spriteDefault;
    [SerializeField]
    SpriteRenderer menu;

    private void Start()
    {
        menu = GetComponentInParent<SpriteRenderer>();
    }

    private void OnMouseEnter()
    {
        menu.sprite = sprite;        
    }

    private void OnMouseExit()
    {
        menu.sprite = spriteDefault;    
    }

}

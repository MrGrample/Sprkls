using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outline : MonoBehaviour
{

    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private StartUpMenu startUpMenu;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
    }

    private void OnMouseOver()
    {
        if (Cursor.visible)
            spriteRenderer.enabled = true;
        gameManager.instance.ChangeCursor(3);
    }

    private void OnMouseExit()
    {
        spriteRenderer.enabled = false;
        gameManager.instance.ChangeCursor(0);
    }
    private void OnMouseDown()
    {
        startUpMenu.StartGame();
    }

}

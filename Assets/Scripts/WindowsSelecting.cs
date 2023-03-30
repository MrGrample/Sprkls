using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsSelecting : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    public OpenningButtonScript releatedPanel;

    public virtual void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public virtual void OnMouseDown()
    {
        StoryTeller.instance.isConsoleSelected = false;
        gameManager.instance.lastClicked.releatedPanel.SetSprite(0);
        gameManager.instance.lastClicked = this;
        gameManager.instance.ChangeMaxOrder();
        releatedPanel.SetSprite(1);
        spriteRenderer.sortingOrder = gameManager.instance.maxOrder;
    }

    private void OnMouseUp()
    {
        spriteRenderer.sortingOrder = gameManager.instance.maxOrder;
    }


}

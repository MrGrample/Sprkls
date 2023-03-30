using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextWindowsMoving : WindowsMoving
{
    private Canvas canvas;

    public override void Awake()
    {
        base.Awake();
        canvas = GetComponentInChildren<Canvas>();
    }

    public override void OnMouseDown()
    {
        base.OnMouseDown();
        transform.position = new Vector3(transform.position.x, transform.position.y, -spriteRenderer.sortingOrder);
        StoryTeller.instance.isConsoleSelected = true;
        canvas.sortingOrder = spriteRenderer.sortingOrder; 
    }

    public override void ChangeOrder(int minusOrder)
    {
        base.ChangeOrder(minusOrder);
        canvas.sortingOrder = spriteRenderer.sortingOrder;
    }
}

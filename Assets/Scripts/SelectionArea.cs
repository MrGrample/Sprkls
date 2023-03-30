using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SelectionArea : WindowsSelecting
{
    [SerializeField]
    private Canvas canvas;

    public override void Awake()
    {
        releatedPanel = GetComponentInParent<WindowsMoving>().releatedPanel;
        spriteRenderer = GetComponentInParent<SpriteRenderer>();
    }

    public override void OnMouseDown()
    {
        base.OnMouseDown();
        spriteRenderer.transform.position = new Vector3(transform.position.x, transform.position.y, -spriteRenderer.sortingOrder);
        if (canvas != null )
        {
            if (canvas.GetComponentInChildren<TextMeshProUGUI>().CompareTag("MainText"))
                StoryTeller.instance.isConsoleSelected = true;
            canvas.sortingOrder = spriteRenderer.sortingOrder;
        }
    }
}

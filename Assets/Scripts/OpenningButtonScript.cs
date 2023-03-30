using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenningButtonScript : MonoBehaviour
{

    [SerializeField]
    Animator animator;
    private SpriteRenderer spriteRenderer;
    [SerializeField]
    private List<Sprite> sprites;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        if (gameManager.instance.lastOpened != this)
        {
            gameManager.instance.ClearLastOpened();
            gameManager.instance.lastOpened = this;
            animator.gameObject.GetComponent<WindowsSelecting>().OnMouseDown();
            SetSprite(1);
            animator.SetBool("IsOpening", true);
            animator.SetBool("IsHiding", false);
        }
    }

    private void OnMouseEnter()
    {
        gameManager.instance.ChangeCursor(3);
    }

    private void OnMouseExit()
    {
        gameManager.instance.ChangeCursor(0);
    }

    public void SetSprite(int number)
    {
        spriteRenderer.sprite = sprites[number];
    }

    private void OnBecameVisible()
    {
        Debug.Log("Hi");
//        animator.gameObject.SetActive(true);
        PanelManager.instance.panels.Add(this.gameObject);
        PanelManager.instance.RearrangePanels();
    }

    private void OnBecameInvisible()
    {
        Debug.Log("Bye");
/*        if (animator != null)
        {
            animator.gameObject.SetActive(false);
        }*/
        PanelManager.instance.panels.Remove(this.gameObject);
        PanelManager.instance.RearrangePanels();
    }

}

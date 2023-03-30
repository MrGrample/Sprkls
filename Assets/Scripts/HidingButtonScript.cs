using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingButtonScript : MonoBehaviour
{

    Animator animator;
    public OpenningButtonScript releatedPanel;

    void Awake()
    {
        releatedPanel = GetComponentInParent<WindowsSelecting>().releatedPanel;
        animator = GetComponentInParent<Animator>();     
    }

    public void OnMouseDown()
    {
        releatedPanel.SetSprite(0);
        animator.SetBool("IsOpening", false);
        animator.SetBool("IsHiding", true);
    }

    private void OnEnable()
    {
        if (PanelManager.instance != null)
            PanelManager.instance.RearrangePanels();
    }
}

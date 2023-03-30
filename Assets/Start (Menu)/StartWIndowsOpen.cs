using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartWIndowsOpen : MonoBehaviour
{

    [SerializeField]
    private GameObject startMenu;

    private void OnMouseDown()
    {
        startMenu.SetActive(!startMenu.activeInHierarchy);
    }

    private void OnMouseEnter()
    {
        gameManager.instance.ChangeCursor(3);
    }

    private void OnMouseExit()
    {
        gameManager.instance.ChangeCursor(0);
    }
}

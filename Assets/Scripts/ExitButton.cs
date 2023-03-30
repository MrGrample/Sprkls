using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitButton : MonoBehaviour
{
    private void OnMouseOver()
    {
        gameManager.instance.ChangeCursor(3);
    }

    private void OnMouseExit()
    {
        gameManager.instance.ChangeCursor(0);
    }

    private void OnMouseDown()
    {
        Debug.Log("Quit");
        Application.Quit();    
    }

}

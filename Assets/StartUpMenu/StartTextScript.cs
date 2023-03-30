using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTextScript : MonoBehaviour
{

    [SerializeField]
    private GameObject menu;
    [SerializeField]
    private GameObject parent;

    private void OnEnd()
    {
        menu.SetActive(true);
        parent.SetActive(false);
    }
}

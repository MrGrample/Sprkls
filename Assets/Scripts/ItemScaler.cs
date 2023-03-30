using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScaler : MonoBehaviour
{

    private void Awake()
    {
        transform.localScale = new Vector2(transform.localScale.x * ((float)Screen.width / (float)Screen.height * 9f / 16f), transform.localScale.y);
    }

}


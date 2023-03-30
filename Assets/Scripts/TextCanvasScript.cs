using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextCanvasScript : MonoBehaviour
{

    private Canvas canvas;

    // Start is called before the first frame update
    void Awake()
    {
        canvas = GetComponent<Canvas>();
        canvas.sortingOrder = 1;
    }

    public void ChangeCanvasOrder(int order)
    {
        canvas.sortingOrder = order;
    }
}

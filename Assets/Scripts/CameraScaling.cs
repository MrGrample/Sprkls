using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScaling : MonoBehaviour
{
    private void Awake()
    {
        if (Camera.main.aspect == 16f / 9f)
        {
            Camera.main.orthographicSize = 2.139f;
        }
        else if (Camera.main.aspect == 16f / 10f)
        {
            Camera.main.orthographicSize = 2.3f;
        }
    }
}

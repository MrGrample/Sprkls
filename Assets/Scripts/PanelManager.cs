using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{

    public static PanelManager instance = null;
    public List<GameObject> panels;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void RearrangePanels()
    {
        float x = -2.05f * ((float)Screen.width / (float)Screen.height * 9f / 16f);
        foreach (GameObject panel in panels)
        {
            if (panel.activeInHierarchy)
            {
                panel.transform.position = new Vector3(x, panel.transform.position.y, panel.transform.position.z);
                x += 0.92f * ((float)Screen.width / (float)Screen.height * 9f / 16f);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{

    public static gameManager instance = null;
    public WindowsSelecting lastClicked;
    public OpenningButtonScript lastOpened;
    public int maxOrder;
    public GameObject[] windows;
    [SerializeField]
    private int maximOrder = 100;
    [SerializeField]
    private Texture2D[] cursors;
    [SerializeField]
    private bool isTesting = false;
    private AudioSource audioSource;

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

        maxOrder = 1;
    }

    private void Start()
    {
        if (!isTesting)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            StoryTeller.instance.ActivateStory();
        }
    }

    public void ChangeMaxOrder()
    {
        maxOrder++;  
        if (maxOrder == maximOrder)
        {
            foreach (GameObject window in windows)
            {
                window.GetComponent<WindowsMoving>().ChangeOrder(maximOrder);
            }
            maxOrder -= maximOrder;
        }
    }

    public void ActivateCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ClearLastOpened()
    {
        lastOpened.SetSprite(0);
    }

    public void FindWindows()
    {
        windows = GameObject.FindGameObjectsWithTag("Window");
        lastClicked = windows[0].GetComponent<WindowsSelecting>();
        lastOpened = lastClicked.releatedPanel;
    }

    public void ChangeCursor(int number)
    {
        Cursor.SetCursor(cursors[number], Vector2.zero, CursorMode.Auto);
    }

}

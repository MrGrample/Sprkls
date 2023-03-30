using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowsMoving : WindowsSelecting
{

    private Vector3 screenPoint;
    private Vector3 offset;
    private Animator animator;
    [SerializeField]
    private float cameraBorders = 0.01f;
    private HidingButtonScript releatedButton;

    public override void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        releatedButton = GetComponentInChildren<HidingButtonScript>();
    }

    void Start()
    {
        spriteRenderer.sortingOrder = 1;    
    }

    public override void OnMouseDown()
    {
        base.OnMouseDown();
        transform.position = new Vector3(transform.position.x, transform.position.y, -spriteRenderer.sortingOrder);
        gameManager.instance.ChangeCursor(1);
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        gameManager.instance.ChangeCursor(4);

        Vector3 cursorPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(cursorPoint) + offset;

        float cameraHeight = Camera.main.orthographicSize * 2.0f;
        float cameraWidth = Camera.main.aspect * cameraHeight; 

        if ((Camera.main.ScreenToWorldPoint(cursorPoint).x < cameraWidth / 2 - cameraBorders)&&(Camera.main.ScreenToWorldPoint(cursorPoint).x > - cameraWidth / 2 + cameraBorders) && (Camera.main.ScreenToWorldPoint(cursorPoint).y < cameraHeight / 2 - cameraBorders) && (Camera.main.ScreenToWorldPoint(cursorPoint).y > -cameraHeight / 2 + cameraBorders)
                && (cursorPosition.x < cameraWidth / 2 - cameraBorders) && (cursorPosition.x > -cameraWidth / 2 + cameraBorders) && (cursorPosition.y < cameraHeight / 2 - cameraBorders) && (cursorPosition.y > -cameraHeight / 2 + cameraBorders))
        {
            transform.position = cursorPosition;
        }
    }

    private void OnMouseUp()
    {
        gameManager.instance.ChangeCursor(0);
    }

    private void OnOpening()
    {
        animator.SetBool("IsHiding", false);
        animator.SetBool("IsOpening", false);
    }

    public virtual void ChangeOrder(int minusOrder)
    {
        spriteRenderer.sortingOrder -= minusOrder;
        transform.position = new Vector3(transform.position.x, transform.position.y, -spriteRenderer.sortingOrder);
    }

    private void OnApplicationQuit()
    {
        Debug.Log("Working");
        releatedButton.OnMouseDown();
    }

    private void OnEnable()
    {
        if (gameManager.instance != null)
            gameManager.instance.FindWindows();
    }

    public void CloseWindow()
    {
        releatedPanel.gameObject.SetActive(false);
        animator.SetBool("IsHiding", true);
        animator.SetBool("IsOpening", false);
    }

    public void OpenWindow()
    {
        gameObject.SetActive(true);
        releatedPanel.gameObject.SetActive(true);
        transform.position = new Vector3(Random.Range(-1.8f, 1.8f), Random.Range(-0.8f, 0.8f));
        animator.SetBool("IsHiding", false);
        animator.SetBool("IsOpening", true);
        base.OnMouseDown();
        transform.position = new Vector3(transform.position.x, transform.position.y, -spriteRenderer.sortingOrder);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSize : MonoBehaviour
{

    SpriteRenderer spriteRenderer;
    public float cameraHeight;
    [SerializeField]
    private float zOffset = 0f;

    private void Awake()
    {
        Camera.main.aspect = (float)Screen.width / (float)Screen.height;
        spriteRenderer = GetComponent<SpriteRenderer>();

        cameraHeight = Camera.main.orthographicSize * 2.0f;
        Vector2 cameraSize = new Vector2(Camera.main.aspect * cameraHeight, cameraHeight);
        Vector2 spriteSize = spriteRenderer.sprite.bounds.size;

        transform.position = new Vector3(0f, 0f, zOffset);
        transform.localScale = new Vector2(cameraSize.x / spriteSize.x, cameraSize.y / spriteSize.y);
    }

}

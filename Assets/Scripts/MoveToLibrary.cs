using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToLibrary : MonoBehaviour
{
    public Texture2D arrow;
    private Texture2D defaultCursor;
    public Vector2 hotspot = Vector2.zero;

    private bool isHovering = false;

    void Start()
    {
        Cursor.SetCursor(defaultCursor, hotspot, CursorMode.Auto);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("entre");
        if (other.CompareTag("Mouse"))
        {
            isHovering = true;
            Cursor.SetCursor(arrow, hotspot, CursorMode.Auto);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("sortie");
        if (other.CompareTag("Mouse"))
        {
            isHovering = false;
            Cursor.SetCursor(defaultCursor, hotspot, CursorMode.Auto);
        }
    }

    void Update()
    {
        if (isHovering && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene("OpheliaLibrary");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToHouse : MoveTo
{
    public Frog frog;

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Mouse"))
        {
            if (frog)
            {
                frog.enabled = false;
            }

            Debug.Log("entre");
            isHovering = true;
            Cursor.SetCursor(arrow, hotspot, CursorMode.Auto);
        }
    }

    protected override void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Mouse"))
        {
            if (frog)
            {
                frog.enabled = true;
            }
           
            Debug.Log("sortie");
            isHovering = false;
            Cursor.SetCursor(defaultCursor, hotspot, CursorMode.Auto);
        }
    }
}

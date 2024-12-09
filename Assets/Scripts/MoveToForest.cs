using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToForest : MoveTo
{
    public Cat cat;
    public Flower flower;

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);
        if (other.CompareTag("Mouse"))
        {
            if (flower && cat)
            {
                flower.enabled = false;
                cat.enabled = false;
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
            if (flower && cat)
            {
                flower.enabled = true;
                cat.enabled = true;
            }

            Debug.Log("sortie");
            isHovering = false;
            Cursor.SetCursor(defaultCursor, hotspot, CursorMode.Auto);
        }
    }
}

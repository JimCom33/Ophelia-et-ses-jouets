using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToForest : MonoBehaviour
{
    public Texture2D arrow;
    private Texture2D defaultCursor;
    public Vector2 hotspot = Vector2.zero;

    public bool isHovering = false;

    public Cat cat;
    public Flower flower;

    void Start()
    {
        Cursor.SetCursor(defaultCursor, hotspot, CursorMode.Auto);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
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

    private void OnTriggerExit2D(Collider2D other)
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

    void Update()
    {
        if (isHovering)
        {
            if (Input.GetMouseButtonDown(0))
            {
                LoadScene();
            }
        }
    }

    private void LoadScene()
    {
        try
        {
            SceneManager.LoadScene("OpheliaMaisonForest");
            Debug.Log("La scène a été chargée avec succès.");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Erreur de chargement : {e.Message}");
        }
    }
}

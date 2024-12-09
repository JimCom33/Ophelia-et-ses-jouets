using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class MoveTo : MonoBehaviour
{
    public Texture2D arrow;
    public Texture2D defaultCursor;
    public Vector2 hotspot = Vector2.zero;

    protected bool isHovering = false;

    public string sceneName;

    void Start()
    {
        Cursor.SetCursor(defaultCursor, hotspot, CursorMode.Auto);
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
 
    }

    protected virtual void OnTriggerExit2D(Collider2D other)
    {
    }

    protected virtual void Update()
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
            // SceneManager.LoadScene("OpheliaMaisonForest");
            SceneManager.LoadScene(sceneName);
            Debug.Log("La scène a été chargée avec succès.");
        }
        catch (System.Exception e)
        {
            Debug.LogError($"Erreur de chargement : {e.Message}");
        }
    }
}

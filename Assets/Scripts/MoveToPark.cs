using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveToPark : MonoBehaviour
{
    public AudioSource scarySoundsParc;
    public Texture2D arrow;
    private Texture2D defaultCursor;
    public Vector2 hotspot = Vector2.zero;
    private bool isHovering = false;
    public Frog frog;
    public Image imageDark;

    void Start()
    {
        Cursor.SetCursor(defaultCursor, hotspot, CursorMode.Auto);
    }

    private void OnTriggerEnter2D(Collider2D other)
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

    private void OnTriggerExit2D(Collider2D other)
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

    void Update()
    {
        if (isHovering && Input.GetMouseButtonDown(0))
        {
            scarySoundsParc.Play();
            if (imageDark)
            {
                imageDark.enabled = true;
            }

            if (Player.Instance)
            {
                Player.Instance.AddErreurGlob();
            }

            //StartCoroutine(GoBackToPark());
        }
    }

    IEnumerator GoBackToPark()
    {
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene("OpheliaParc");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveToPark : MoveTo
{
    public AudioSource scarySoundsParc;
    public Frog frog;
    public Image imageDark;

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

    protected override void Update()
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

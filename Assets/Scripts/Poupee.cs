using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Poupee : ItemData
{
    private int wrongClicks;

    public GameObject poupee;
    public GameObject oursonEpeurant;

    public AudioSource scarySound;

    void Start()
    {
        FindAnyObjectByType<Text>().ShowText("", 0.1f);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject mouseObject = GameObject.Find("Mouse");

            Collider2D mouseCollider = mouseObject?.GetComponent<Collider2D>();
            if (mouseCollider != null)
            {
                mouseCollider.enabled = false;
            }

            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider)
            {
                Debug.Log($"Objet détecté : {hit.collider.gameObject.name}");

                if (hit.collider.gameObject == gameObject)
                {
                    Debug.Log("Poupee");

                    Debug.Log($"Vous avez cliqué sur {gameObject.name}");

                    FindAnyObjectByType<Text>().ShowText("Ophélia : Ah elle était là tout ce temps!");

                    StartCoroutine(ShowObjectForSeconds(2f, poupee));

                    StartCoroutine(DisplayGoodEnding());
                }
            }
            else
            {
                WrongClick();
            }

            if (mouseCollider != null)
            {
                mouseCollider.enabled = true;
            }
        }
    }

    private void WrongClick()
    {
        wrongClicks++;

        if (wrongClicks > 2)
        {
            if (scarySound)
            {
                scarySound.Play();
            }
            StartCoroutine(ShowObjectForSeconds(2f, oursonEpeurant));

            if (Player.Instance)
            {
                Player.Instance.AddErreurGlob();
            }
        }
    }

    IEnumerator ShowObjectForSeconds(float delay, GameObject varObject)
    {
        varObject.SetActive(true);
        yield return new WaitForSeconds(delay);

        varObject.SetActive(false);
    }

    IEnumerator DisplayGoodEnding()
    {
        yield return new WaitForSeconds(3.0f);
        FindAnyObjectByType<Text>().Clear();
        SceneManager.LoadScene("GoodEnding");
    }
}

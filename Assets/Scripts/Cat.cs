using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public AudioSource catMiaw;

    public AudioSource catScary;

    private int catClick = 0;
    private Player player;

    void Start()
    {
        player = FindAnyObjectByType<Player>();
        catMiaw.enabled = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && FindAnyObjectByType<Flower>().flowerDone)
        {
            GameObject mouseObject = GameObject.Find("Mouse");

            Collider2D mouseCollider = mouseObject?.GetComponent<Collider2D>();
            if (mouseCollider != null)
            {
                mouseCollider.enabled = false;
            }

            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log($"Objet d�tect� : {hit.collider.gameObject.name}");

                if (hit.collider.gameObject == gameObject)
                {
                    Debug.Log("chat");

                    Debug.Log($"Vous avez cliqu� sur {gameObject.name}");

                    CatClicks();
                }
            }          
            
            if (mouseCollider != null)
            {
                mouseCollider.enabled = true;
            }
        }
    }

    private IEnumerator CatMiawDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        catMiaw.enabled = true;

        catMiaw.Play();
    }

    private void CatClicks()
    {
        catClick++;

        if (catClick > 3)
        {
            catScary.Play();
            player.AddErreurGlob();
        }
        else
        {
            StartCoroutine(CatMiawDelay(1f));
        }
    }
}

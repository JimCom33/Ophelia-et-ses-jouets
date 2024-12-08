using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Frog : MonoBehaviour
{
    public AudioSource frogDie;
    public GameObject moveTo;
    public GameObject moveToPark;
    public GameObject bouton;

    private int frogClicks = 0;

    public BoxCollider2D boxCollider;
    public GameObject frog;
    public GameObject deadFrog;

    void Start()
    {

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

            if (hit.collider != null)
            {
                Debug.Log($"Objet détecté : {hit.collider.gameObject.name}");

                if (hit.collider.gameObject == gameObject)
                {
                    Debug.Log("frog");

                    Debug.Log($"Vous avez cliqué sur {gameObject.name}");

                    FrogClicks();

                    if (frogClicks == 1)
                    {
                        StartCoroutine(FrogDialogue());
                    }
                }
            }

            if (mouseCollider != null)
            {
                mouseCollider.enabled = true;
            }
        }
    }

    private void FrogClicks()
    {
        frogClicks++;
        Debug.Log("click grenouille");

        if (frogClicks > 3)
        {
            deadFrog.SetActive(true);
            frogDie.Play();
            boxCollider.enabled = false;
            Debug.Log("grenouille meurt");

            if (Player.Instance)
            {
                Player.Instance.AddErreurGlob();
            }

            FindAnyObjectByType<Text>().ShowText("", 0.0f);
            frog.SetActive(false);
            moveTo.SetActive(true);
        }
    }

    private IEnumerator FrogDialogue()
    {
        yield return new WaitForSeconds(2f);

        FindAnyObjectByType<Text>().ShowText("Ophélia: Bonjour Grenouille, as-tu vu ma poupée? (Click droit pour passer)");

        yield return WaitForRightClick();

        FindAnyObjectByType<Text>().ShowText("Grenouille: Oui, elle marchait ici il n’y a pas longtemps. Elle a échappé ceci. (Click droit pour passer)");

        //ShowBouton
        StartCoroutine(ShowBoutonForSeconds(1f));

        yield return WaitForRightClick();

        FindAnyObjectByType<Text>().ShowText("Ophélia : Ça vient de ma poupée! Il a dû se détacher et a tombé. Sais-tu où elle est allée? (Click droit pour passer)");

        yield return WaitForRightClick();

        FindAnyObjectByType<Text>().ShowText("Grenouille : Elle se dirigeait vers la maison. (Click droit pour passer)");

        yield return WaitForRightClick();

        FindAnyObjectByType<Text>().ShowText("Ophélia : Ah, c’est ma maison! Allons voir dans ma chambre. (Click droit pour passer)");

        moveTo.SetActive(true);

        yield return WaitForRightClick();

        FindAnyObjectByType<Text>().ShowText("", 2f);
    }

    private IEnumerator WaitForRightClick()
    {
        while (Input.GetMouseButton(1))
        {
            yield return null;
        }

        while (!Input.GetMouseButtonDown(1))
        {
            yield return null;
        }
    }

    IEnumerator ShowBoutonForSeconds(float delay)
    {
        yield return new WaitForSeconds(delay);
        bouton.SetActive(true);

        yield return new WaitForSeconds(delay);
        bouton.SetActive(false);
    }
}

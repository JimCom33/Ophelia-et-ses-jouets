using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Frog : MonoBehaviour
{
    public AudioSource frogDie;

    public GameObject moveTo;

    public GameObject moveToPark;

    private int frogClicks = 0;

    private Player player;

    public BoxCollider2D boxCollider;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
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

                    StartCoroutine(FrogDialogue());

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
            //frogDie.Play();

            boxCollider.enabled = false;

            Debug.Log("grenouille meurt");

            //bouton tombe

            Player.Instance.AddErreurGlob();
        }
    }

    private IEnumerator FrogDialogue()
    {
        yield return new WaitForSeconds(2f);

        FindAnyObjectByType<Text>().ShowText("Ophélia: Bonjour grenouille, as-tu vu ma poupée? (Click droit pour passer)");

        yield return WaitForRightClick();

        FindAnyObjectByType<Text>().ShowText("Grenouille: Oui, elle marchait ici il n’y a pas longtemps. Elle a laissé ceci derrière elle. (Click droit pour passer)");

        //affiche le bouton

        yield return WaitForRightClick();

        FindAnyObjectByType<Text>().ShowText("Ophélia : Ça vient de ma poupée! Il a dû se détacher et tomber. Sais-tu ou elle est allé? (Click droit pour passer)");

        yield return WaitForRightClick();

        FindAnyObjectByType<Text>().ShowText("Grenouille : Elle se dirigeait vers la maison ici. (Click droit pour passer)");

        yield return WaitForRightClick();

        FindAnyObjectByType<Text>().ShowText("Ophélia : Ah, mais c’est ma maison! Allons voir dans la chambre. (Click droit pour passer)");

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
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.Arm;
using static UnityEditor.ShaderData;

public class Flower : ItemData
{
    private bool hasBeenClicked = false;
    private int wrongClicks = 0;

    public bool flowerDone = false;

    public GameObject opheliaFachee;
    public GameObject opheliaNeutre;
    public GameObject ophelia;

    private DialogueParc dialogueParc;
    private Player player;

    void Start()
    {
        player = FindAnyObjectByType<Player>();
        dialogueParc = FindAnyObjectByType<DialogueParc>();
    }

    private void Update()
    {
        if (dialogueParc.isInteracting)
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
                        Debug.Log("Fleur");

                        if (!hasBeenClicked)
                        {
                            hasBeenClicked = true;
                            Debug.Log($"Vous avez cliqué sur {gameObject.name}");

                            StartCoroutine(ShowMessageAfterDelay(5f));
                        }
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
    }

    private void WrongClick()
    {
        wrongClicks++;

        if (wrongClicks == 1)
        {
            StartCoroutine(ShowOpheliaForSeconds(3f, opheliaNeutre));
            Debug.Log("ophelia neutre");
        }

        if (wrongClicks == 3)
        {
            //Visage plein écran
            StartCoroutine(ShowOpheliaForSeconds(3f, opheliaFachee));
            Debug.Log("ophelia fachee");
            FindAnyObjectByType<Text>().ShowText("Tu ne m'aides pas à chercher. Je veux ma poupée, comprends-tu?", 5f);
            player.AddErreurGlob();
        }
    }

    private IEnumerator ShowMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        FindAnyObjectByType<Text>().ShowText("Non, ma poupée n'est pas là.", 5f);

        yield return new WaitForSeconds(3f);

        FindAnyObjectByType<Text>().ShowText("Je veux flatter le chat maintenant!", 5f);

        FlowerDone();
    }

    public void FlowerDone()
    {
        flowerDone = true;
    }

    IEnumerator ShowOpheliaForSeconds(float delay, GameObject varOphelia)
    {
        yield return new WaitForSeconds(delay);
        varOphelia.SetActive(true);

        yield return new WaitForSeconds(delay);
        varOphelia.SetActive(false);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.Arm;
using static UnityEditor.ShaderData;

public class Flower : MonoBehaviour
{
    private bool hasBeenClicked = false;
    private int wrongClicks = 0;

    public bool flowerDone = false;

    private void Update()
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
                Debug.Log($"Objet d�tect� : {hit.collider.gameObject.name}");


                if (hit.collider.gameObject == gameObject)
                {
                    Debug.Log("Fleure");

                    if (!hasBeenClicked)
                    {
                        hasBeenClicked = true;
                        Debug.Log($"Vous avez cliqu� sur {gameObject.name}");


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

    private void WrongClick()
    {
        wrongClicks++;

        if(wrongClicks == 1)
        {
            //Visage facher
            Debug.Log("ophelia facher");
        }

        if(wrongClicks == 3)
        {
            //Visage plein �cran
            Debug.Log("Visage pleine ecran");
            FindAnyObjectByType<Text>().ShowText("J�ai dit la fleur. Comprends-tu?", 5f);
            FindAnyObjectByType<Player>().AddErreurGlob();
        }
    }

    private IEnumerator ShowMessageAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        FindAnyObjectByType<Text>().ShowText("Non, ma poup�e n'est pas la.", 5f);

        yield return new WaitForSeconds(3f);

        FindAnyObjectByType<Text>().ShowText("Je veux flatter le chat maintenant!", 5f);

        FlowerDone();
    }

    public void FlowerDone()
    {
        flowerDone = true;
    }
}

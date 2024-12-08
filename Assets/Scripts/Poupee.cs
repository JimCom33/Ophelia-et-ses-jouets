using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poupee : MonoBehaviour
{
    private int wrongClicks;
    
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        FindAnyObjectByType<Text>().ShowText("", 0.1f);
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
                    Debug.Log("Poupee");

                    Debug.Log($"Vous avez cliqué sur {gameObject.name}");

                    FindAnyObjectByType<Text>().ShowText("Ophélia : Ah elle était là tout ce temps!");

                    
                    //afficher poupee

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

        if (wrongClicks > 3)
        {
            //plus sombre
            //son etrange
            //ourson sur le lit épeurant

            Player.Instance.AddErreurGlob();
        }
    }
}

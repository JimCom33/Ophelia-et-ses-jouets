using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class DialogueParc : MonoBehaviour
{

    public bool isInteracting = false;

    private string[] dialogueLines = new string[]
    {
        "Des parents d’une petite fille de 7 ans t’ont demandé de t’occuper de leur fille pendant quelques heures puisqu’ils sont partis assister à un événement important. (Click droit pour passer)",
        "Tu ne connais pas leur fille Ophélia, mais elle semble gentille, quoique légèrement étrange. (Click droit pour passer)",
        "Seras-tu capable de lui garder compagnie? Va-t-elle t’apprécier? (Click droit pour passer)",
        "Ophélia: “Allo, je dois trouver ma poupée. Je deviens très triste sans elle. (Click droit pour passer)",
        "Tu ne peux lui refuser, elle semble être très attachée à ce jouet, même si tu ne sais pas encore de quoi il a l’air. (Click droit pour passer)",
        "La quête commence. (Click droit pour passer)"
    };

    private int currentLineIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        isInteracting = true;
        currentLineIndex = 0;
        ShowNextDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        
        
            if (Input.GetMouseButtonDown(1))
            {
                ShowNextDialogue();
            }
        
    }

    private void ShowNextDialogue()
    {
        
        if (currentLineIndex < dialogueLines.Length)
        {
            
            FindAnyObjectByType<Text>().ShowText(dialogueLines[currentLineIndex]);
            currentLineIndex++;
        }
        else
        {
            FindAnyObjectByType<Text>().ShowText("Elle est peut-être derrière cette fleur?", 2f);
            isInteracting = false;
        }
    }
}

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
        "Des parents d�une petite fille de 7 ans t�ont demand� de t�occuper de leur fille pendant quelques heures puisqu�ils sont partis assister � un �v�nement important. (Click droit pour passer)",
        "Tu ne connais pas leur fille Oph�lia, mais elle semble gentille, quoique l�g�rement �trange. (Click droit pour passer)",
        "Seras-tu capable de lui garder compagnie? Va-t-elle t�appr�cier? (Click droit pour passer)",
        "Oph�lia: �Allo, je dois trouver ma poup�e. Je deviens tr�s triste sans elle. (Click droit pour passer)",
        "Tu ne peux lui refuser, elle semble �tre tr�s attach�e � ce jouet, m�me si tu ne sais pas encore de quoi il a l�air. (Click droit pour passer)",
        "La qu�te commence. (Click droit pour passer)"
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
            FindAnyObjectByType<Text>().ShowText("Elle est peut-�tre derri�re cette fleur?", 2f);
            isInteracting = false;
        }
    }
}

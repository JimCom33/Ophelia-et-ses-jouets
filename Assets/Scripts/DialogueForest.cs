using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueForest : MonoBehaviour
{
    void Start()
    {
        FindAnyObjectByType<Text>().ShowText("Oph�lia : La grenouille sait peut-�tre o� est mon jouet?", 5f);
    }

    void Update()
    {
    //    if (Input.GetMouseButtonDown(1))
    //    {
    //        ShowNextDialogue();
    //    }
    }

    private void ShowNextDialogue()
    {
        
    }
}

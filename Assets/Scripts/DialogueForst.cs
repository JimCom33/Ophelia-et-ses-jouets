using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueForst : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindAnyObjectByType<Text>().ShowText("Oph�lia : La grenouille a peut-�tre mon jouet?", 5f);
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

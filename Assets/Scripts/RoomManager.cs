using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeRoom : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        SceneManager.LoadScene("OpheliaLibrary");

        SceneManager.LoadScene("OpheliaRoom");
    }
}

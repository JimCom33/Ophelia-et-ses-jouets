using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int erreurGlobal = 0;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void AddErreurGlob()
    {
        erreurGlobal++;

        Debug.Log($"erreur : {erreurGlobal}");
    }
}

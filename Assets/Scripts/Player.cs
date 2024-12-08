using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    public int erreurGlobal = 0;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void AddErreurGlob()
    {
        erreurGlobal++;

        Debug.Log($"erreur : {erreurGlobal}");
    }
}

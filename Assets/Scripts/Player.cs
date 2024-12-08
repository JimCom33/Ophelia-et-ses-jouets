using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;
    public int erreurGlobal = 0;
    private EndingManager endingManager;

    void Start()
    {
        //endingManager = FindAnyObjectByType<EndingManager>();
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
        if (erreurGlobal > 3)
        {
            if (!endingManager)
            {
                endingManager = FindAnyObjectByType<EndingManager>();
            }

            if (endingManager) 
            {
                endingManager.TriggerBadEnding();
            }
        }
    }
}

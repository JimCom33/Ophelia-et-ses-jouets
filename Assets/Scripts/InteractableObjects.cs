using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjects : MonoBehaviour, IInteractable
{
    public int numberOfClicks;
    public bool isClicked = false;

    public void Interact()
    {
        isClicked = true;
        numberOfClicks++;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}

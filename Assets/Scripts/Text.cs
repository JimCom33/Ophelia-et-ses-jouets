using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Text : MonoBehaviour
{
    public Image fadeBackground;
    public TMP_Text message;
    private float messageTimer;
    public Image imageDark;

    internal void ShowText(string text)
    {
        ShowText(text, 30f);
    }

    internal void ShowText(string text, float duration)
    {
        message.text = text;
        fadeBackground.enabled = true;
        messageTimer = duration;
    }

    private void Update()
    {
        if (messageTimer > 0)
        {
            messageTimer -= Time.deltaTime;
            if (messageTimer <= 0)
            {
                Clear();
            }
        }
    }

    public void Clear()
    {
        fadeBackground.enabled = false;
        message.text = "";
    }

    private void Start()
    {
        //Clear();
    }

    public void ScreenDarker()
    {
        imageDark.enabled = true;
    }
}

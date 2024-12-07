using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingManager : MonoBehaviour
{
    bool badEndingTriggered = false;

    public GameObject goodOphelia;
    public GameObject badOphelia;

    void Start()
    {
        
    }

    void Update()
    {
        if (badEndingTriggered)
        {
            goodOphelia.SetActive(false);
            badOphelia.SetActive(true);
            StartCoroutine(ScaleChangeOverTime(2f, 2f));
            //playSound
            SceneManager.LoadScene("EndMenuGood");
        }
        else
        {
            SceneManager.LoadScene("EndMenuGood");
        }
    }

    private IEnumerator ScaleChangeOverTime(float duration, float scale)
    {
        Vector3 opheliaScale = badOphelia.GetComponent<Transform>().localScale;
        var initialScale = opheliaScale;
        var finalScale = Vector3.one * scale;
        var elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            var time = elapsedTime / duration;
            opheliaScale = Vector3.Lerp(initialScale, finalScale, time);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        opheliaScale = finalScale;
    }
}

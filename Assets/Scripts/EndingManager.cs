using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingManager : MonoBehaviour
{
    public bool badEndingTriggered = false;
    public AudioSource scarySoundsRoom;
    public AudioSource scaryLaugh;
    public AudioSource scaryMusic;
    public AudioSource happyMusic;

    public GameObject goodOphelia;
    public GameObject badOphelia;

    void Start()
    {
        
    }

    void Update()
    {

    }

    public void TriggerBadEnding()
    { 
        happyMusic.Pause();
        goodOphelia.SetActive(false);
        badOphelia.SetActive(true);
        StartCoroutine(ScaleChangeOverTime(8f, 8f));
        scaryMusic.Play();
        scaryLaugh.Play();
        scarySoundsRoom.Play();
        StartCoroutine(GoBackToMenu());
    }

    bool isScaling = false;
    private IEnumerator ScaleChangeOverTime(float duration, float scale)
    {
        if (isScaling)
        {
            yield break;
        }
        isScaling = true;
        Transform transform = badOphelia.GetComponent<Transform>();
        Vector3 opheliaScale = transform.localScale;
        var initialScale = opheliaScale;
        var finalScale = opheliaScale * scale;
        var elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            var time = elapsedTime / duration;
            transform.localScale = Vector3.Lerp(initialScale, finalScale, time);
            elapsedTime += Time.deltaTime;
            Debug.Log(elapsedTime);
            yield return null;
        }

        opheliaScale = finalScale;
    }

    IEnumerator GoBackToMenu()
    {
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene("Menu");
    }
}

using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class FadeUI : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float fadeDuration = 0.5f;
    public float visibleTime = 2f;

    void Start()
    {
        if (canvasGroup != null)
        {
            canvasGroup.alpha = 0f; // Oculta visualmente
        }
    }


    public void ShowMessage()
    {
        StopAllCoroutines();
        StartCoroutine(FadeInAndOut());
    }

    IEnumerator FadeInAndOut()
    {
        // Fade in
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(0f, 1f, t / fadeDuration);
            yield return null;
        }

        // Espera visible
        yield return new WaitForSeconds(visibleTime);

        // Fade out
        t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(1f, 0f, t / fadeDuration);
            yield return null;
        }
    }
}


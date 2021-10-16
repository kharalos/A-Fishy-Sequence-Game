using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using TMPro;
public class SubtitleManager : MonoBehaviour
{
    TextMeshProUGUI subtitleText;
    Dictionary<string, float> textQueue = new Dictionary<string, float>();
    Coroutine coroutine;
    void Start()
    {
        subtitleText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void AddTextToSubtitles(string text, float time, bool purgeQueue)
    {
        if (purgeQueue)
        {
            if (coroutine != null)
                StopCoroutine(coroutine);
            coroutine = null;
            textQueue.Clear();
        }
        if (!textQueue.ContainsKey(text))
            textQueue.Add(text, time);
        else return;
        if (coroutine == null)
            coroutine = StartCoroutine(ShowText());
    }
    IEnumerator ShowText()
    {
        var theItem = textQueue.First();
        textQueue.Remove(textQueue.Keys.First());
        string text = theItem.Key;
        float time = theItem.Value;
        subtitleText.text = text;
        for (float i = 0; i <= 1; i += 0.01f)
        {
            subtitleText.alpha = i;
            yield return new WaitForSeconds(0.01f);
        }
        yield return new WaitForSeconds(time);
        for (float i = 1; i >= 0; i -= 0.01f)
        {
            subtitleText.alpha = i;
            yield return new WaitForSeconds(0.01f);
        }
        if (textQueue.Count != 0)
            coroutine = StartCoroutine(ShowText());
        else coroutine = null;
    }
}

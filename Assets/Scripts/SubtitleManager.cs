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

    public void AddTextToSubtitles(string text, float time)
    {
        textQueue?.Add(text, time);
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
        for(int i = 0; i < 101; i++)
        {
            subtitleText.alpha = i;
        }
        yield return new WaitForSeconds(time);
        for (int i = 100; i >= 0; i--)
        {
            subtitleText.alpha = i;
        }
        if (textQueue.Count != 0)
            coroutine = StartCoroutine(ShowText());
    }
}

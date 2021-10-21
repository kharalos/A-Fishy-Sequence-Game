using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDManager : GameManager
{
    [SerializeField]
    private GameObject endPanel;
    [SerializeField]
    private TextMeshProUGUI top;
    public void EndGame(string text)
    {
        endPanel.SetActive(true);
        Time.timeScale = 0;
        top.text = text;
    }

}

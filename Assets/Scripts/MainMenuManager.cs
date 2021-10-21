using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject settingsPanel,creditsPanel;
    private void Awake()
    {
        Time.timeScale = 1f;
    }

    public void OpenSettingsPanel()
    {
        creditsPanel.SetActive(false);
        if (settingsPanel.activeInHierarchy) settingsPanel.SetActive(false);
        else settingsPanel.SetActive(true);
    }
    public void OpenCreditsPanel()
    {
        settingsPanel.SetActive(false);
        if (creditsPanel.activeInHierarchy) creditsPanel.SetActive(false);
        else creditsPanel.SetActive(true);
    }
    public void SelectScene(int i)
    {
        SceneManager.LoadScene(i);
    }
    public void Exit()
    {
        Application.Quit();
    }
}

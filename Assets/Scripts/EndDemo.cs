using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndDemo : MonoBehaviour
{
    public GameObject endPanel;
    public void RestartScene()
    {
        SceneManager.LoadScene(0);
    }
    public void Exit()
    {
        Application.Quit();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Character")
        {
            endPanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}

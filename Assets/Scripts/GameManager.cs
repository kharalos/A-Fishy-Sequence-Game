using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [HideInInspector]
    private void Start()
    {
        Unpause();
    }
    private void Update()
    {

    }
    public virtual void Pause()
    {
        Time.timeScale = 0f;
        CursorUnlock();
    }
    public virtual void Unpause()
    {
        Time.timeScale = 1f;
        CursorLock();
    }

    public virtual void CursorUnlock()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public virtual void CursorLock()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public virtual void SelectScene(int i)
    {
        SceneManager.LoadScene(i);
    }
    public virtual void Exit()
    {
        Application.Quit();
    }
}

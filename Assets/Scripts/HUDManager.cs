using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class HUDManager : GameManager
{
    [SerializeField]
    private GameObject endPanel,pausePanel;
    [SerializeField]
    private TextMeshProUGUI top;
    [SerializeField]
    private Volume volume;
    private bool paused;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && !paused) Pause();

        else if(Input.GetKeyDown(KeyCode.Tab) && paused) Unpause();
        if (!Application.isFocused) Pause();
    }
    public override void Pause()
    {
        base.Pause();
        paused = true;
        FindObjectOfType<Controller>().LockControl = true;
        if (!endPanel.activeInHierarchy) pausePanel.SetActive(true);
    }
    public override void Unpause()
    {
        base.Unpause();
        paused = false;
        FindObjectOfType<Controller>().LockControl = false;
        pausePanel.SetActive(false);
    }
    public void ChangeMotionBlur(Toggle change)
    {
        VolumeProfile profile = volume.sharedProfile;
        if (!profile.TryGet<MotionBlur>(out MotionBlur blur))
        {
            blur = profile.Add<MotionBlur>(false);
        }
        if (change.isOn) { blur.active = true; Debug.Log("Blur on."); }
        else { blur.active = false; Debug.Log("Blur off."); }
    }
    AudioSource music;
    public void MusicAction()
    {
        music = FindObjectOfType<GameManager>().GetComponent<AudioSource>();
        if(music.volume == 1f) music.volume = 0f;
        else music.volume = 1f;
    }
    public void ChangeSoundVolume(float value)
    {
        AudioListener.volume = value;
    }
    public void ChangeQualityLevel(int level)
    {
        QualitySettings.SetQualityLevel(level);
    }
    public void ChaneMouseSensitivity(float value)
    {
        FindObjectOfType<Controller>().MouseSensitivity = value;
    }
    public void EndGame(string text)
    {
        endPanel.SetActive(true);
        CursorUnlock();
        Pause();
        top.text = text;
    }
}

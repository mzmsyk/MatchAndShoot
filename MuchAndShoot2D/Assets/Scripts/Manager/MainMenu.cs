using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [Header("Settings")]
    public GameObject settingsButton;
    public GameObject settingsPanel;
    [Header("Start")]
    public GameObject startButton;
    public GameObject abilityPanel;


  

    public void SettingsButton()
    {
        Debug.Log("settings");
        settingsButton.SetActive(false);
        settingsPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void SettingsBackButton()
    {
        settingsButton.SetActive(true);
        settingsPanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void StartButton()
    {
        Time.timeScale = 1;
        abilityPanel.SetActive(false);
        startButton.SetActive(false);
        
    }
}

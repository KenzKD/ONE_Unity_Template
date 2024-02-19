using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{

    public static SettingsManager Instance;
    public static bool GameisPaused = false, GameisStarted = false;
    public Slider _bgmSlider, _sfxSlider;
    public Button settingsButton;
    public GameObject introPanel, settingsPanel, scorePanel, settingObject, restartObject;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        Time.timeScale = 0f;
        GameisStarted = false;
        GameisPaused = true;
        introPanel.SetActive(true);
        settingsPanel.SetActive(false);
        scorePanel.SetActive(false);
        settingObject.SetActive(true);
        restartObject.SetActive(false);
    }

    void Start()
    {
        if (PlayerPrefs.HasKey("bgmSavedVolume") || PlayerPrefs.HasKey("sfxSavedVolume"))
        {
            Debug.Log("Playerprefs Exist");
            _bgmSlider.value = PlayerPrefs.GetFloat("bgmSavedVolume");
            _sfxSlider.value = PlayerPrefs.GetFloat("sfxSavedVolume");
        }
        else
        {
            _bgmSlider.value = _bgmSlider.maxValue;
            _sfxSlider.value = _sfxSlider.maxValue;
        }

        BgmSliderVolume();
        SfxSliderVolume();
    }

    public void StartGame()
    {
        introPanel.SetActive(false);
        scorePanel.SetActive(true);
        restartObject.SetActive(true);
        Time.timeScale = 1f;
        GameisPaused = false;
        GameisStarted = true;
    }

    public bool AllowGamePlay()
    {
        return !EventSystem.current.IsPointerOverGameObject() && SettingsManager.GameisStarted && !SettingsManager.GameisPaused;
    }

    public void BgmSliderVolume()
    {
        AudioManager.Instance.BGMVolume(_bgmSlider.value * 0.05f);
        PlayerPrefs.SetFloat("bgmSavedVolume", _bgmSlider.value);
    }

    public void SfxSliderVolume()
    {
        AudioManager.Instance.SFXVolume(_sfxSlider.value * 0.2f);
        PlayerPrefs.SetFloat("sfxSavedVolume", _sfxSlider.value);
    }

    public void Pause()
    {
        settingsPanel.SetActive(true);
        settingObject.SetActive(false);
        if (GameisStarted)
        {
            scorePanel.SetActive(false);
            Time.timeScale = 0f;
            GameisPaused = true;
        }
    }

    public void Resume()
    {
        settingsPanel.SetActive(false);
        settingObject.SetActive(true);
        if (GameisStarted)
        {
            scorePanel.SetActive(true);
            Time.timeScale = 1f;
            GameisPaused = false;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Destroy(gameObject);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
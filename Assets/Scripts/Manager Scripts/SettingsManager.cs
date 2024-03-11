using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class SettingsManager : MonoBehaviour
{
    // Singleton instance for easy access
    public static SettingsManager Instance;

    // Game state flags
    public static bool GameisPaused = false, GameisStarted = false;

    // UI elements
    public Slider _bgmSlider, _sfxSlider;
    public Button settingsButton;
    public GameObject introPanel, settingsPanel, scorePanel, settingObject, restartObject;

    private Image settingsBGM;


    // Initialize game state and UI
    void Awake()
    {
        Instance = this;
        Time.timeScale = 0f;
        GameisStarted = false;
        GameisPaused = true;
        introPanel.SetActive(true);
        settingsPanel.SetActive(false);
        scorePanel.SetActive(false);
        settingObject.SetActive(true);
        restartObject.SetActive(false);
        settingsBGM = settingsPanel.GetComponent<Image>();
    }

    // Load volume settings or set to max
    void Start()
    {
        _bgmSlider.value = PlayerPrefs.GetFloat("bgmSavedVolume", _bgmSlider.maxValue);
        _sfxSlider.value = PlayerPrefs.GetFloat("sfxSavedVolume", _sfxSlider.maxValue);

        // Apply the volume settings
        BgmSliderVolume();
        SfxSliderVolume();
    }

    // Start the game
    public void StartGame()
    {
        introPanel.SetActive(false);
        scorePanel.SetActive(true);
        restartObject.SetActive(true);
        Time.timeScale = 1f;
        settingObject.SetActive(true);
        settingObject.transform.DOScale(1, 0.5f).SetEase(Ease.OutExpo).SetUpdate(true);
        GameisPaused = false;
        GameisStarted = true;
    }

    // Check if gameplay is allowed
    public bool AllowGamePlay()
    {
        return !EventSystem.current.IsPointerOverGameObject() && SettingsManager.GameisStarted && !SettingsManager.GameisPaused;
    }

    // Adjust BGM volume
    public void BgmSliderVolume()
    {
        AudioManager.Instance.BGMVolume(_bgmSlider.value * 0.05f);
        PlayerPrefs.SetFloat("bgmSavedVolume", _bgmSlider.value);
    }

    // Adjust SFX volume
    public void SfxSliderVolume()
    {
        AudioManager.Instance.SFXVolume(_sfxSlider.value * 0.2f);
        PlayerPrefs.SetFloat("sfxSavedVolume", _sfxSlider.value);
    }

    // Pause the game
    public void Pause()
    {
        settingsPanel.SetActive(true);
        settingsBGM.DOFade(0.8f, 0.5f).SetEase(Ease.OutExpo).SetUpdate(true);
        settingObject.transform.DOScale(0.001f, 0.25f).SetEase(Ease.InExpo).SetUpdate(true).OnComplete(() =>
        {
            settingObject.SetActive(false);
        });
        if (GameisStarted)
        {
            scorePanel.SetActive(false);
            Time.timeScale = 0f;
            GameisPaused = true;
        }
    }

    // Resume the game
    public void Resume()
    {
        settingsBGM.DOFade(0.001f, 0.001f).SetUpdate(true);
        settingsPanel.SetActive(false);
        settingObject.SetActive(true);
        settingObject.transform.DOScale(1, 0.25f).SetEase(Ease.OutExpo).SetUpdate(true);
        if (GameisStarted)
        {
            scorePanel.SetActive(true);
            Time.timeScale = 1f;
            GameisPaused = false;
        }
    }

    // Restart the game
    public void Restart()
    {
        DOTween.KillAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Destroy(gameObject);
    }

    // Load the menu
    public void LoadMenu()
    {
        DOTween.KillAll();
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    // Quit the game
    public void QuitGame()
    {
        DOTween.KillAll();
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
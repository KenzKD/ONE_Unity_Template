using UnityEngine;
using TMPro;
using MilkShake;
using System.Collections;
using DG.Tweening;

public class ScoreManager : MonoBehaviour
{
    // Singleton instance for easy access
    public static ScoreManager Instance;

    // UI elements
    public GameObject WinScreen, WrongText;
    public float score, total_Score;
    public TextMeshProUGUI scoreText;
    public ShakePreset ShakePreset;

    // Initialize game state and UI
    void Awake()
    {
        Instance = this;
        scoreText.text = $"{score}/{total_Score}";
        WinScreen.SetActive(false);
    }

    // Add points to the score
    public void AddPoint(float value)
    {
        score += value;
        Debug.Log($"New score: {score}");
        scoreText.text = $"{score}/{total_Score}";
        CheckWin();
    }

    // Check if the score equals the total score
    void CheckWin()
    {
        if (score == total_Score)
        {
            StartCoroutine(Win(0f));
        }
    }

    // Handle winning the game
    IEnumerator Win(float seconds)
    {
        AudioManager.sfxAllowOverlap = true;
        // AudioManager.Instance.PlaySFX("Bonus");
        yield return new WaitForSeconds(seconds);
        AudioManager.sfxAllowOverlap = false;
        Time.timeScale = 0f;
        VideoManager.Instance.PlayVideo("Win");
        Debug.Log("Win!");
        AudioManager.Instance.bgmSource.Stop();
        AudioManager.Instance.sfxSource.Stop();
        AudioManager.Instance.PlaySFX("Win");
        WinScreen.SetActive(true);
    }

    // Handle wrong answer
    public void Wrong(Vector3 newPosition)
    {
        AudioManager.Instance.PlaySFX("Wrong");
        GameObject Text = Instantiate(WrongText, newPosition, Quaternion.identity);
        Text.transform.DOScale(0f, 0.5f).SetEase(Ease.InExpo).SetDelay(0.5f).OnComplete(() => Destroy(Text));
        Shaker.ShakeAll(ShakePreset);
    }
}
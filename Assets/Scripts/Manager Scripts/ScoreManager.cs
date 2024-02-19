using UnityEngine;
using TMPro;
using MilkShake;
using System.Collections;


public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public GameObject WinScreen, WrongText;
    public float score, total_Score;
    public TextMeshProUGUI scoreText;
    public ShakePreset ShakePreset;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        scoreText.text = score.ToString() + "/" + total_Score.ToString();
        WinScreen.SetActive(false);
    }

    public void AddPoint(float value)
    {
        score += value;
        Debug.Log(score);
        scoreText.text = score.ToString() + "/" + total_Score.ToString();
        CheckWin();
    }

    void CheckWin()
    {
        if (score == total_Score)
        {
            StartCoroutine(Win(0f));
        }
    }

    IEnumerator Win(float seconds)
    {
        // AudioManager.Instance.PlaySFX("Bonus");
        yield return new WaitForSeconds(seconds);
        Time.timeScale = 0f;
        VideoManager.Instance.PlayVideo("Win");
        Debug.Log("Win!");
        AudioManager.Instance.bgmSource.Stop();
        AudioManager.Instance.sfxSource.Stop();
        AudioManager.Instance.PlaySFX("Win");
        WinScreen.SetActive(true);
    }

    public void Wrong(Vector3 newPosition)
    {
        AudioManager.Instance.PlaySFX("Wrong");
        Shaker.ShakeAll(ShakePreset);
        StartCoroutine(InstanceText(newPosition));
    }

    IEnumerator InstanceText(Vector3 newPosition)
    {
        GameObject Text = Instantiate(WrongText, newPosition, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Destroy(Text);
    }
}
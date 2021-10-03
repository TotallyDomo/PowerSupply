using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UI : MonoBehaviour
{
    const string SOURCE_URL = "https://github.com/TotallyDomo/PowerSupply";

    public static Action<string> GameOver;

    [SerializeField]
    GameObject GameOverObject;

    [SerializeField]
    TMP_Text GameOverText, TimeText, ScoreText;

    public static bool GameOverState = false;

    void Awake()
    {
        Application.targetFrameRate = 60;
        GameOverState = false;
        Time.timeScale = 1;
        GameOver += OnGameOver;
    }

    void OnDestroy() => GameOver -= OnGameOver;

    void OnGameOver(string message)
    {
        // trigger game over
        GameOverState = true;
        GameOverText.text = message;
        var time = TimeSpan.FromSeconds(Clock.time);
        TimeText.text = $"{time.TotalMinutes:00}:{time.TotalSeconds % 60:00}";
        ScoreText.text = $"{GameManager.Score}";
        GameOverObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void LoadCoreScene() => SceneManager.LoadScene(1);

    public void LoadMainMenu() => SceneManager.LoadScene(0);

    public void OnSourceClick() => Application.OpenURL(SOURCE_URL);

}

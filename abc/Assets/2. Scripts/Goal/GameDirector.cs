using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI pointText;

    public float gameTime = 60.0f;
    private float timeRemaining;
    private int point = 0;
    private bool isGameOver = false;

    public static int finalScore = 0; //게임 오버 씬에 전달할 점수

    void Start()
    {
        timeRemaining = gameTime;
        UpdateUI();
    }

    void Update()
    {
        if (isGameOver) return;

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            isGameOver = true;

            finalScore = point; //점수 저장
 
            SceneManager.LoadScene("GameOver"); // 게임 오버 씬으로 이동
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        if (timerText != null)
            timerText.text = timeRemaining.ToString("F1");

        if (pointText != null)
            pointText.text = "Score: " + point;
    }

    public void AddPoint(int amount)
    {
        if (isGameOver) return;

        point += amount;
        UpdateUI();
    }

    public void ForceGameOver()
    {
        if (isGameOver) return;

        isGameOver = true;
        finalScore = point;

        SceneManager.LoadScene("GameOver");
    }
}
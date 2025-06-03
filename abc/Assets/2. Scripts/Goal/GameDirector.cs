using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI pointText;

    public float gameTime = 60.0f;
    private float timeRemaining;
    private int point = 0;
    private bool isGameOver = false;

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

            Debug.Log("게임 종료! 최종 점수: " + point);
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
}
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        scoreText.text = $"Score: {GameDirector.finalScore}";
    }

    public void OnRetry()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void OnQuit()
    {
        Debug.Log("Quit 버튼 눌림");
        Application.Quit();
    }
}

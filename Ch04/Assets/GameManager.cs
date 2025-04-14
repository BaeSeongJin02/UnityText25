using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  // Correct namespace for TextMeshPro
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour
{
    public GameObject car;
    public GameObject flag;
    public TextMeshProUGUI distance;

    void Start()
    {
        // Ensure objects are found if not assigned in Inspector
        if (car == null) car = GameObject.Find("car");
        if (flag == null) flag = GameObject.Find("flag");
        if (distance == null)
        {
            GameObject distanceObj = GameObject.Find("Distance");
            if (distanceObj != null)
            {
                distance = distanceObj.GetComponent<TextMeshProUGUI>();
            }
        }
    }

    void Update()
    {
        if (car == null || flag == null || distance == null) return;

        float length = flag.transform.position.x - car.transform.position.x;
        distance.text = "°Å¸® : " + length.ToString("F2") + "m";
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReloadScene()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene("currentScene");
    }
}

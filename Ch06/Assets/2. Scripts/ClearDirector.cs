using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearDirector : MonoBehaviour
{
    // Start is called before the first frame update
    //void Start()
    //{
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        SceneManager.LoadScene("GameScene");
    //    }
    //}

    public void QuitGame()
    {
        Application.Quit();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

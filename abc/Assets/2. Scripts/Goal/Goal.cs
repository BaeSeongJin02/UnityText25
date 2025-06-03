using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    private bool goalScored = false;

    void OnTriggerEnter(Collider other)
    {
        if (goalScored) return;

        if (other.CompareTag("Ball"))
        {
            goalScored = true;

            Debug.Log("공이 골대를 통과했습니다!");

            // 점수 증가
            GameDirector director = FindObjectOfType<GameDirector>();
            if (director != null)
                director.AddPoint(1);
            else
                Debug.LogWarning("GameDirector를 찾을 수 없습니다.");

            // 골대 제거
            Destroy(gameObject);
        }
    }
}
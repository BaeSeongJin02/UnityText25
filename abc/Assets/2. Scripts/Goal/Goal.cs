using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    private bool goalScore = false;

    [HideInInspector]
    public GoalSpawner spawner; // 외부에서 할당 받음
    void Start()
    {
        if (spawner == null)
            spawner = FindObjectOfType<GoalSpawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("트리거 발생: " + other.name);

        if (goalScore) return;

        if (other.CompareTag("Ball"))
        {
            goalScore = true;
            Debug.Log("골대 통과");

            GameDirector director = FindObjectOfType<GameDirector>();
            if (director != null)
                director.AddPoint(1);

            // 스포너가 연결되었을 때만 호출
            if (spawner != null)
                spawner.SpawnGoal();
            else
                Debug.LogWarning("spawner가 연결되지 않았습니다.");

            Destroy(gameObject);
        }
    }
}
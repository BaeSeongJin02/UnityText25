using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalSpawner : MonoBehaviour
{
    public GameObject goalPrefab;
    public Transform ball;

    private float minDistance = 10f; //생성 거리 제한
    private float goalHeight = 1f;    //골대 높이 조정

    private Transform[] goalPositions;

    void Start()
    {
        // 자식 오브젝트 위치 수집
        goalPositions = GetComponentsInChildren<Transform>();

        // 공 자동 할당
        if (ball == null)
        {
            GameObject foundBall = GameObject.FindWithTag("Ball");
            if (foundBall != null)
                ball = foundBall.transform;
        }
    }

    public void SpawnGoal()
    {
        if (goalPrefab == null || goalPositions.Length <= 1 || ball == null)
        {
            return;
        }

        int index;
        Vector3 position;

        do
        {
            index = Random.Range(1, goalPositions.Length);
            position = goalPositions[index].position;
        }
        while (Vector3.Distance(position, ball.position) < minDistance);

        position.y = goalHeight;

        // 골대 생성
        GameObject goal = Instantiate(goalPrefab, position, Quaternion.identity);

        // ▶ Goal.cs의 spawner 연결
        Goal goalScript = goal.GetComponent<Goal>();
        if (goalScript != null)
        {
            goalScript.spawner = this;
        }

        // 월드 위치 유지하면서 부모 설정
        goal.transform.SetParent(goalPositions[index], true);
    }
}
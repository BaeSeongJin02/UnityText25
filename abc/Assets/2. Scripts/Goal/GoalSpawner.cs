using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalSpawner : MonoBehaviour
{
    public GameObject goalPrefab;
    public Transform ball;

    public float minDistance = 10f;
    public float goalHeight = 1f;
    public float spawnInterval = 10f;

    private float timer = 0f;
    private List<Transform> goalPositions = new List<Transform>();
    private List<int> usedIndexes = new List<int>(); // 이미 사용된 위치 인덱스

    void Start()
    {
        foreach (Transform child in transform)
        {
            goalPositions.Add(child);
        }

        if (ball == null)
        {
            GameObject foundBall = GameObject.FindWithTag("Ball");
            if (foundBall != null)
                ball = foundBall.transform;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnGoal();
            timer = 0f;
        }
    }

    public void SpawnGoal()
    {
        if (goalPrefab == null || goalPositions.Count == 0 || ball == null)
            return;

        // 모든 위치에 골대가 생긴 경우 중단
        if (usedIndexes.Count >= goalPositions.Count)
        {
            return;
        }

        int index;
        Vector3 position;
        int safety = 20;

        do
        {
            index = Random.Range(0, goalPositions.Count);
            position = goalPositions[index].position;
            safety--;
        }
        while ((usedIndexes.Contains(index) || Vector3.Distance(position, ball.position) < minDistance) && safety > 0);

        if (safety <= 0)
        {
            return;
        }

        position.y = goalHeight;

        Quaternion randomRotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);

        GameObject goal = Instantiate(goalPrefab, position, randomRotation);
        goal.tag = "Goal";

        usedIndexes.Add(index); // 생성한 위치 인덱스 저장
    }
}
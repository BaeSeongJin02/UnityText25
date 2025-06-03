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

    void Start()
    {
        // 자신의 자식 Transform 자동 수집
        foreach (Transform child in transform)
        {
            goalPositions.Add(child);
        }

        // 공 자동 찾기
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

        int index;
        Vector3 position;
        int safety = 20;

        do
        {
            index = Random.Range(0, goalPositions.Count);
            position = goalPositions[index].position;
            safety--;
        }
        while (Vector3.Distance(position, ball.position) < minDistance && safety > 0);

        position.y = goalHeight;

        GameObject goal = Instantiate(goalPrefab, position, Quaternion.identity);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalSpawner : MonoBehaviour
{
    public GameObject goalPrefab;
    public Transform ball;

    private float minDistance = 10f; //���� �Ÿ� ����
    private float goalHeight = 1f;    //��� ���� ����

    private Transform[] goalPositions;

    void Start()
    {
        // �ڽ� ������Ʈ ��ġ ����
        goalPositions = GetComponentsInChildren<Transform>();

        // �� �ڵ� �Ҵ�
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

        // ��� ����
        GameObject goal = Instantiate(goalPrefab, position, Quaternion.identity);

        // �� Goal.cs�� spawner ����
        Goal goalScript = goal.GetComponent<Goal>();
        if (goalScript != null)
        {
            goalScript.spawner = this;
        }

        // ���� ��ġ �����ϸ鼭 �θ� ����
        goal.transform.SetParent(goalPositions[index], true);
    }
}
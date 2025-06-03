using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    private bool goalScore = false;

    [HideInInspector]
    public GoalSpawner spawner; // �ܺο��� �Ҵ� ����
    void Start()
    {
        if (spawner == null)
            spawner = FindObjectOfType<GoalSpawner>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ʈ���� �߻�: " + other.name);

        if (goalScore) return;

        if (other.CompareTag("Ball"))
        {
            goalScore = true;
            Debug.Log("��� ���");

            GameDirector director = FindObjectOfType<GameDirector>();
            if (director != null)
                director.AddPoint(1);

            // �����ʰ� ����Ǿ��� ���� ȣ��
            if (spawner != null)
                spawner.SpawnGoal();
            else
                Debug.LogWarning("spawner�� ������� �ʾҽ��ϴ�.");

            Destroy(gameObject);
        }
    }
}
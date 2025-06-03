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

            Debug.Log("���� ��븦 ����߽��ϴ�!");

            // ���� ����
            GameDirector director = FindObjectOfType<GameDirector>();
            if (director != null)
                director.AddPoint(1);
            else
                Debug.LogWarning("GameDirector�� ã�� �� �����ϴ�.");

            // ��� ����
            Destroy(gameObject);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTarget : MonoBehaviour
{
    public GameObject targetPrefab;

    private Transform[] destinations;

    void Start()
    {
        destinations = GetComponentsInChildren<Transform>();
        Debug.Log("Ÿ�� ��ġ �ĺ� ��: " + destinations.Length);
    }

    public void GenerateTargetObject()
    {
        int index = Random.Range(1, destinations.Length); // 0�� �ڱ� �ڽ��̹Ƿ� ����

        Vector3 spawnPos = destinations[index].position;

        GameObject target = Instantiate(targetPrefab, spawnPos, Quaternion.identity);

        // �ʿ��ϴٸ� �θ�� ���̱� (���� ����)
        target.transform.SetParent(destinations[index]);
    }
}

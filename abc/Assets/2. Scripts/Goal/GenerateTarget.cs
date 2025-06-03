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
        Debug.Log("타겟 위치 후보 수: " + destinations.Length);
    }

    public void GenerateTargetObject()
    {
        int index = Random.Range(1, destinations.Length); // 0은 자기 자신이므로 제외

        Vector3 spawnPos = destinations[index].position;

        GameObject target = Instantiate(targetPrefab, spawnPos, Quaternion.identity);

        // 필요하다면 부모로 붙이기 (선택 사항)
        target.transform.SetParent(destinations[index]);
    }
}

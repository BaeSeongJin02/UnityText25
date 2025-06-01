using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // 따라갈 대상 (공)
    public Vector3 offset = new Vector3(0f, 5f, -6f); // 카메라 위치 오프셋
    public float smoothSpeed = 5f; // 따라가는 속도

    void LateUpdate()
    {
        // 목표 위치 = 공 위치 + 오프셋
        Vector3 desiredPosition = target.position + offset;

        // 부드럽게 이동
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        // 공을 항상 바라봄
        transform.LookAt(target);
    }
}

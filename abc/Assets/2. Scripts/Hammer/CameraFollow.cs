using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // 해머 또는 공
    public Vector3 offset = new Vector3(0f, 5f, -10f); // 뒤 + 위
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (target == null) return;

        // 해머가 바라보는 방향에 따라 offset을 회전시킴
        Vector3 rotatedOffset = target.rotation * offset;

        // 목표 위치 계산
        Vector3 desiredPosition = target.position + rotatedOffset;

        // 부드럽게 이동
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        // 해머가 바라보는 방향을 따라 카메라도 회전
        transform.LookAt(target.position + target.forward * 5f); // 약간 앞을 보게 하기
    }
}
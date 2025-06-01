using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // ���� ��� (��)
    public Vector3 offset = new Vector3(0f, 5f, -6f); // ī�޶� ��ġ ������
    public float smoothSpeed = 5f; // ���󰡴� �ӵ�

    void LateUpdate()
    {
        // ��ǥ ��ġ = �� ��ġ + ������
        Vector3 desiredPosition = target.position + offset;

        // �ε巴�� �̵�
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        // ���� �׻� �ٶ�
        transform.LookAt(target);
    }
}

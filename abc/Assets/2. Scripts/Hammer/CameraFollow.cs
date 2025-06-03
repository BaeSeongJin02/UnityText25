using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // �ظ� �Ǵ� ��
    public Vector3 offset = new Vector3(0f, 5f, -10f); // �� + ��
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (target == null) return;

        // �ظӰ� �ٶ󺸴� ���⿡ ���� offset�� ȸ����Ŵ
        Vector3 rotatedOffset = target.rotation * offset;

        // ��ǥ ��ġ ���
        Vector3 desiredPosition = target.position + rotatedOffset;

        // �ε巴�� �̵�
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        // �ظӰ� �ٶ󺸴� ������ ���� ī�޶� ȸ��
        transform.LookAt(target.position + target.forward * 5f); // �ణ ���� ���� �ϱ�
    }
}
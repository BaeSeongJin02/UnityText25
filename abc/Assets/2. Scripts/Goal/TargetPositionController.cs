using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPositionController : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 2f); // �� �信�� ��ġ Ȯ�ο� ��ü
    }
}
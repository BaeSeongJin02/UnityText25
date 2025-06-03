using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPositionController : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 2f); // 씬 뷰에서 위치 확인용 구체
    }
}
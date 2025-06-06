using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHammer : MonoBehaviour
{
    public Transform ball;
    private float followDistance = 2f;
    private float heightOffset = 0.2f;
    private float rotateSpeed = 90f;

    private float angle = 0f;
    private int rotateDir = 0;

    void Update()
    {
        // 키보드 입력 (반전된 방향)
        int horizontal = Input.GetKey(KeyCode.RightArrow) ? -1 :
                         Input.GetKey(KeyCode.LeftArrow) ? 1 : 0;

        // UI 버튼 입력이 우선
        int inputDir = rotateDir != 0 ? rotateDir : horizontal;

        if (inputDir != 0)
        {
            angle += inputDir * rotateSpeed * Time.deltaTime;
            UpdateHammerTransform();
        }
    }

    void UpdateHammerTransform()
    {
        Vector3 dir = Quaternion.Euler(0, angle, 0) * Vector3.back;
        transform.position = ball.position + dir * followDistance + Vector3.up * heightOffset;
        transform.rotation = Quaternion.LookRotation(-dir);
    }

    public float GetAngle() => angle;

    // UI 버튼에 연결할 함수
    public void StartRotateLeft() => rotateDir = 1;
    public void StartRotateRight() => rotateDir = -1;
    public void StopRotate() => rotateDir = 0;
}
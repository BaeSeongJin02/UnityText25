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
        // Ű���� �Է� (������ ����)
        int horizontal = Input.GetKey(KeyCode.RightArrow) ? -1 :
                         Input.GetKey(KeyCode.LeftArrow) ? 1 : 0;

        // UI ��ư �Է��� �켱
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

    // UI ��ư�� ������ �Լ�
    public void StartRotateLeft() => rotateDir = 1;
    public void StartRotateRight() => rotateDir = -1;
    public void StopRotate() => rotateDir = 0;
}
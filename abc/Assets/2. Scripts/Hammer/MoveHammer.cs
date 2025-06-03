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

    void Update()
    {
        float horizontal = Input.GetKey(KeyCode.RightArrow) ? 1 :
                          Input.GetKey(KeyCode.LeftArrow) ? -1 : 0;

        if (horizontal != 0)
        {
            angle += horizontal * rotateSpeed * Time.deltaTime;
            UpdateHammerTransform();
        }
    }

    void UpdateHammerTransform()
    {
        Vector3 dir = Quaternion.Euler(0, angle, 0) * Vector3.back;
        transform.position = ball.position + dir * followDistance + Vector3.up * heightOffset;
        transform.rotation = Quaternion.LookRotation(-dir);
    }

    public float GetAngle()
    {
        return angle;
    }
}
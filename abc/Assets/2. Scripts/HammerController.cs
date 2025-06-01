using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerController : MonoBehaviour
{
    public Transform ball;
    private MoveHammer moveHammer; // MoveHammer 스크립트 참조

    public float backDistance = 0.3f;
    public float forwardDistance = 0.5f;
    public float moveDuration = 0.4f;
    public float heightOffset = 0.3f;
    public float followDistance = 1.5f;

    private float mouseDownTime;
    public float minPower = 5f;
    public float maxPower = 40f;
    public float powerMultiplier = 10f;

    private float moveTimer = 0f;
    private bool isSwinging = false;

    private Vector3 startPos, backPos, forwardPos;

    void Start()
    {
        moveHammer = GetComponent<MoveHammer>();
    }

    void Update()
    {
        if (!isSwinging && Input.GetMouseButtonUp(0))
            StartSwing();

        if (isSwinging)
            AnimateSwing();

        if (Input.GetMouseButtonDown(0))
        {
            mouseDownTime = Time.time; // 누른 순간 시간 저장
        }
    }

    void StartSwing()
    {
        isSwinging = true;
        moveTimer = 0f;

        float angle = moveHammer.GetAngle();
        Vector3 dir = Quaternion.Euler(0, angle, 0) * Vector3.back;

        startPos = ball.position + dir * followDistance + Vector3.up * heightOffset;
        backPos = ball.position + dir * (followDistance + backDistance) + Vector3.up * heightOffset;
        forwardPos = ball.position + dir * (followDistance - forwardDistance) + Vector3.up * heightOffset;

        //충격력 계산 및 적용
        float heldTime = Time.time - mouseDownTime;
        float power = Mathf.Clamp(heldTime * powerMultiplier, minPower, maxPower);

        Vector3 forceDir = (ball.position - transform.position).normalized;

        Rigidbody ballRb = ball.GetComponent<Rigidbody>();
        ballRb.AddForce(forceDir * power, ForceMode.Impulse);
    }

    void AnimateSwing()
    {
        moveTimer += Time.deltaTime;
        float t = moveTimer / moveDuration;

        if (t < 0.5f)
            transform.position = Vector3.Lerp(startPos, backPos, t / 0.5f);
        else if (t < 1f)
            transform.position = Vector3.Lerp(backPos, forwardPos, (t - 0.5f) / 0.5f);
        else
            isSwinging = false;
    }
}
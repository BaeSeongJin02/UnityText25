using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerController : MonoBehaviour
{
    public Transform ball;
    private MoveHammer moveHammer;

    private float backDistance = 0.3f;
    private float forwardDistance = 0.5f;
    private float moveDuration = 0.4f;
    private float heightOffset = 0.4f;
    private float followDistance = 1.5f;

    private float mouseDownTime;
    private float minPower = 20f;
    private float maxPower = 400f;
    private float powerMultiplier = 20f;

    private float moveTimer = 0f;
    private bool isSwinging = false;

    private Vector3 startPos, backPos, forwardPos;

    void Start()
    {
        moveHammer = GetComponent<MoveHammer>();
    }

    void Update()
    {
        if (isSwinging)
            AnimateSwing();
    }

    //버튼 누를 때 호출
    public void OnSmashDown()
    {
        mouseDownTime = Time.time;
    }

    //버튼 뗄 때 호출
    public void OnSmashUp()
    {
        if (!isSwinging)
            StartSwing();
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
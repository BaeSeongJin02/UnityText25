using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float accelerationMultiplier = 30f;
    public float stopThreshold = 0.6f;

    private Rigidbody rb;
    private bool isMoving = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        //  자연 감속 적용
        rb.drag = 1.5f;
        rb.angularDrag = 0.05f;
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

    void FixedUpdate()
    {
        if (isMoving && rb.velocity.sqrMagnitude < stopThreshold * stopThreshold)
        {
            rb.velocity = Vector3.zero;
            isMoving = false;
        }
    }

    public void Hit(Vector3 direction, float pressTime)
    {
        float force = pressTime * accelerationMultiplier;

        rb.AddForce(direction.normalized * force, ForceMode.Impulse);
        isMoving = true;
    }

    public bool IsMoving()
    {
        return isMoving;
    }
}
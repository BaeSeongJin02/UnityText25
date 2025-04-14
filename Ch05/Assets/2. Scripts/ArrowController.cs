using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public float moveStep = 0.07f;
    public float r1 = 0.5f;
    public float r2 = 1.0f;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        player = GameObject.Find("player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, -moveStep, 0);

        if (transform.position.y < -7f)
        {
            Destroy(gameObject);
        }

        //충돌 판정
        Vector2 p1 = transform.position;
        Vector2 p2 = player.transform.position;
        Vector2 dir = p1 - p2;
        float distance = dir.magnitude;

        if(distance < r1 + r2)
        {
            Destroy(gameObject);
        }
    }
}

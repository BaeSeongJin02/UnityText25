using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    Transform playerTR;
    GenerateTarget gt;

    // Start is called before the first frame update
    void Start()
    {
        playerTR = GameObject.Find("Player").transform;
        gt = GameObject.FindAnyObjectByType<GenerateTarget>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(playerTR);
        transform.Rotate(0, 180, 0);
    }

    private void OnCollisionEnter(Collision collsion)
    {
        Destroy(gameObject);
        Destroy(collsion.gameObject);
        gt.GenerateTargetObject();
    }
}

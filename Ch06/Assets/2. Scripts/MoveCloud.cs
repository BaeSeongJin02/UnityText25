using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCloud : MonoBehaviour
{

    float avgSpeed = 0.05f;
    float range = 0.02f;
    float maxWidth = 10f;

    float moveSpeed;
    int direction = 1;

    private void Start()
    {
        moveSpeed = avgSpeed;
    }

    // Update is called once per frame
    void Update()
    {

        if (transform.position.x > maxWidth){
            moveSpeed = Random.Range(avgSpeed - range, avgSpeed + range);
            direction = -1;
        }
        if (transform.position.x < -maxWidth)
        {
            direction = 1;
        }
        {
            
        }
        transform.Translate(moveSpeed*direction, 0, 0);
    }
}

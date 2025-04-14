using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RouletteController : MonoBehaviour
{
    float rotSpeed = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            rotSpeed = 10;
        }

        if (rotSpeed == 0) return;

        transform.Rotate(0,0,rotSpeed);
        //transform.localRotation = new Quaternion(0f, 0f, 1f, 0f);

        rotSpeed *= 0.99f;
        if (rotSpeed < 0.01)
            rotSpeed = 0;
    }
}

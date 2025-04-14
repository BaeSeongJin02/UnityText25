using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carcontroller : MonoBehaviour
{
    public float SpeedRatio = 0.0o1f;
    public float stoSpeed = 0.04f;
    public float decreaseRate = 0.97f;

    float speed = 0f;
    Vector2 startPos;
    Vector2 endPos;
    AudioSource audio;

    bool gameEnded = false;


    void Start()
    {
        Application.targetFrameRate = 60;
        audio = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        if (gameEnded) return;

        if(Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
            //speed = startSpeed;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            endPos = Input.mousePosition;
            float swipeLength = endPos.x - startPos.x;
            speed = swipeLength * SpeedRatio / 10000.0f;
            audio.Play();
            carStrted = true;
        }
       
        //transform.position += new Vector3(speed, 0, 0);
        //transform.rotation *= Quaternion.Euler(0, 0, speed);

        transform.Translate(speed, 0, 0);
        speed *= decreaseRate;

        if(carStarted && speed < stopSpeed)
        {
            speed = 0f;
            gameEnded = true;
        }

    }
}

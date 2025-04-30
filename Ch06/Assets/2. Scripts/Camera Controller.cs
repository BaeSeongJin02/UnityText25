using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Player;

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = Player.transform.position;
        transform.position = new Vector3(
            transform.position.x,
            playerPos.y,
            transform.position.z
            );
    }
}

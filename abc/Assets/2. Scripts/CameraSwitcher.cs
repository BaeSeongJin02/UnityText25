using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera aimingCamera;   // 공 칠 때 카메라
    public Camera mainCamera;     // 골대 보는 기본 카메라

    public void SwitchToAimingCamera()
    {
        aimingCamera.enabled = true;
        mainCamera.enabled = false;
    }

    public void SwitchToMainCamera()
    {
        aimingCamera.enabled = false;
        mainCamera.enabled = true;
    }
}
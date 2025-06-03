using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Camera aimingCamera;   // �� ĥ �� ī�޶�
    public Camera mainCamera;     // ��� ���� �⺻ ī�޶�

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
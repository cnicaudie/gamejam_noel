using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //==========// ATTRIBUTES //==========//

    // PUBLIC
    public Transform m_player;
    public Transform m_target;

    public float m_rotationSpeed = 5f;

    // PRIVATE
    private Vector3 m_cameraOffset;

    //==========// METHODS //==========//

    void Start()
    {
        // Base constant offset (third person view)
        m_cameraOffset = new Vector3(0f, 20f, -20f);
    }

    private void Update()
    {
        ToggleCamera();
    }

    void LateUpdate()
    {
        if (Input.GetKey(KeyCode.Mouse2))
        {
            CameraRotation();
        }

        // Apply the camera offset
        transform.position = m_player.position + m_cameraOffset;

        // We should always point towards the player 
        transform.LookAt(m_player);
    }

    private void CameraRotation()
    {
        // From : https://www.youtube.com/watch?v=xcn7hz7J7sI&t=24s&ab_channel=Jayanam
        Quaternion camRotationAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * m_rotationSpeed, Vector3.up);
        m_cameraOffset = camRotationAngle * m_cameraOffset;
    }

    private void ToggleCamera()
    {
        gameObject.SetActive(!GameManager.s_isInMenu);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class PlayerMovement : MonoBehaviour
{

    //==========// ATTRIBUTES //==========//

    // PUBLIC
    public CharacterController m_playerController;
    public Transform m_cameraTransform;

    public float m_speed = 10f;

    // PRIVATE
    private float m_turnSmoothTime = 0.1f;
    private float m_turnSmoothVelocity;

    private float m_gravity = 9.8f;
    private float m_gSpeed = 0;

    private float m_horizontalMove;
    private float m_verticalMove;

    //==========// METHODS //==========//

    void FixedUpdate()
    {
        // We get the horizontal and vertical move (arrow keys and/or see project settings)
        m_horizontalMove = Input.GetAxisRaw("Horizontal");
        m_verticalMove = Input.GetAxisRaw("Vertical");

        // If the player is grounded, no need to apply gravity
        if (m_playerController.isGrounded)
        {
            m_gSpeed = 0f;
        }
        // Otherwise, we apply gravity
        else
        {
            m_gSpeed -= m_gravity * Time.fixedDeltaTime; // apply gravity acceleration to speed:
        }

        // Computes the player movement
        MovePlayer();
    }

    private void MovePlayer()
    {
        // We get the wanted direction and normalize it
        Vector3 direction = new Vector3(m_horizontalMove, 0f, m_verticalMove).normalized;

        // If the player is supposed to move in a direction
        if (direction.magnitude >= 0.1f)
        {
            // We get its target angle using maths (where its face is pointing)
            // See Brackeys tutorial to understand :
            // Link : https://www.youtube.com/watch?v=4HpC--2iowE&ab_channel=Brackeys
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + m_cameraTransform.eulerAngles.y;

            // We use this new angle to have smooth rotations of the player
            // To understand, see link above
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref m_turnSmoothVelocity, m_turnSmoothTime);

            // We finally apply the rotation
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            // Compute the final direction (based on the target angle)
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            // Apply the gravity
            moveDirection.y = m_gSpeed;

            // And move the player using the Unity based Character Controller
            m_playerController.Move(moveDirection * m_speed * Time.fixedDeltaTime);
        }
        // If the player falls off the ground, we check its y position
        else if (transform.position.y < -10f)
        {
            // And we reset its position to avoid falling forever
            // This based position can be replaced if needed
            transform.position = new Vector3(17f, 6.5f, -40f);
        }
        // Otherwise, if the player isn't moving in any given direction
        else
        {
            // We just apply the gravity
            m_playerController.Move(new Vector3(0f, m_gSpeed, 0f) * m_speed * Time.fixedDeltaTime);
        }

    }


}

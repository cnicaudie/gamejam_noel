using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //==========// ATTRIBUTES //==========//

    // PUBLIC
    public Transform m_player;

    //==========// METHODS //==========//

    void Update()
    {
        // The camera follows the player with an offset
        // We can do something more advanced later (maybe use cinemaschine ?)
        transform.position = m_player.position + new Vector3(0f, 20f, -20f);
    }
}

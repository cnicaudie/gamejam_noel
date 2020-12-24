using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    //==========// ATTRIBUTES //==========//

    // PUBLIC
    public Plane m_portalIn;
    public Plane m_portalOut;

    public Player m_player;

    //==========// METHODS //==========//

    void Awake()
    {
        m_player = FindObjectOfType<Player>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("TP REQUEST : " + other.name);

        if (m_player.m_CanTeleport)
        {
            TakePortal();
        }
    }

    public void TakePortal()
    {

        if (m_portalIn.IsInZone(m_player.transform.position))
        {
            // Make sure that "Auto sync transforms" in Project Settings > Physics is enabled
            // Otherwise it doesn't work, see : https://scholarslab.lib.virginia.edu/blog/teleporting-in-Unity3D/
            m_player.transform.position = m_portalOut.transform.position;

            Debug.Log("TELEPORTATION !!");
            m_player.m_CanTeleport = false;
        }
    }

}

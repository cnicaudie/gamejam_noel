using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileLight : MonoBehaviour
{
    //==========// ATTRIBUTES //==========//

    // PUBLIC
    public Zone m_zone;
    public Light m_light;
    public Player m_player;

    //==========// METHODS //==========//

    void Awake()
    {
        m_player = FindObjectOfType<Player>();
    }

    public void dragTowards(Vector3 position)
    {
        Vector3 displacement = (position - transform.position) * m_player.m_Speed * Time.deltaTime;

        Debug.Log(m_zone.IsInZone(transform.position + m_zone.ProjectOnZoneSpace(displacement)));

        // Check if this movement will get the light object out of the zone
        if (m_zone.IsInZone(transform.position + m_zone.ProjectOnZoneSpace(displacement)))
        {
            displacement = m_zone.ProjectOnZoneSpace(displacement);
            // move the light toward the target pos
            transform.position += displacement;
        }
    }

    public void toggleLight()
    {
        this.m_light.gameObject.SetActive(!this.m_light.gameObject.activeSelf);
    }
}

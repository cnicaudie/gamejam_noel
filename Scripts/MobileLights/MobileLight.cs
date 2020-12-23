using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileLight : MonoBehaviour
{
    public Zone m_zone;
    public Light m_light;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void dragTowards(Vector3 position)
    {
        Vector3 displacement = (position - transform.position)*Time.deltaTime;

        Debug.Log(m_zone.IsInZone(transform.position + m_zone.ProjectOnZoneSpace(displacement)));

        // Check if this movement will get the light object out of the zone
        if( m_zone.IsInZone(transform.position + m_zone.ProjectOnZoneSpace(displacement)) )
        {
            displacement = m_zone.ProjectOnZoneSpace(displacement);
            // move the light toward the target pos TODO : match speed with the player's
            transform.position += displacement;
        }
    }

    public void toggleLight()
    {
        this.m_light.gameObject.SetActive(!this.m_light.gameObject.activeSelf);
    }
}

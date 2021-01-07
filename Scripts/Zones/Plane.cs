using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : Zone
{

    //==========// ATTRIBUTES //==========//

    // BOUNDS OF THE ZONE
    [SerializeField]
    float m_xMinValue = 0;
    [SerializeField]
    float m_xMaxValue = 0;
    [SerializeField]
    float m_zMinValue = 0;
    [SerializeField]
    float m_zMaxValue = 0;

    // X/Y CURRENT POSITION
    [SerializeField]
    float m_xValue = 0;
    [SerializeField]
    float m_zValue = 0;

    // VECTOR REPRESENTATION
    [SerializeField]
    Vector3 m_planeVector = Vector3.zero;

    //==========// METHODS //==========//

    public override Vector3 ProjectOnZoneSpace(Vector3 position)
    {
        return Vector3.ProjectOnPlane(position, transform.up);
    }

    public override bool IsInZone(Vector3 position)
    {
        m_planeVector = ProjectOnZoneSpace(position - this.transform.position);
        m_xValue = m_planeVector.x;
        m_zValue = m_planeVector.z;

        if (m_xValue <= m_xMaxValue && m_xValue >= m_xMinValue && m_zValue <= m_zMaxValue && m_zValue >= m_zMinValue)
        {
            return true;
        }

        return false;
    }

}

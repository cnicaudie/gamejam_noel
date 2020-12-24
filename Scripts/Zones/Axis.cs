using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axis : Zone
{
    //==========// ATTRIBUTES //==========//

    // BOUNDS OF THE ZONE
    [SerializeField]
    float m_minValue = 0;
    [SerializeField]
    float m_maxValue = 0;

    // CURRENT POSITTION
    [SerializeField]
    float m_axisValue = 0;

    // VECTOR REPRESENTATION
    [SerializeField]
    Vector3 m_axisVector = Vector3.zero;

    //==========// METHODS //==========//

    public override Vector3 ProjectOnZoneSpace(Vector3 position)
    {
        return Vector3.Project(position, transform.right);
    }

    /// <summary>
    /// Checks if the given position is respecting the zone's condition (i.e. whether the position is in the zone)
    /// </summary>
    /// <param name="position">Position to check</param>
    /// <returns>true if the position belongs to the zone, false otherwise</returns>
    public override bool IsInZone(Vector3 position)
    {
        m_axisVector = ProjectOnZoneSpace(position - this.transform.position);
        m_axisValue = m_axisVector.magnitude;

        if (m_axisValue <= m_maxValue && m_axisValue >= m_minValue)
        {
            return true;
        }

        return false;
    }
}

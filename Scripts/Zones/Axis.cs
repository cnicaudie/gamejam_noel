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

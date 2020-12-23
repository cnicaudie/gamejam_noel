using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axis : Zone
{
    [SerializeField]
    float m_minValue = 0;
    [SerializeField]
    float m_maxValue = 0;
    [SerializeField]
    float m_axisValue = 0;
    [SerializeField]
    Vector3 m_axisVector = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
        float axisValue = ProjectOnZoneSpace(position - this.transform.position).magnitude;
        m_axisVector = ProjectOnZoneSpace(position - this.transform.position);
        m_axisValue = axisValue;
        if (axisValue <= m_maxValue && axisValue >= m_minValue)
        {
            return true;
        }

        return false;
    }
}

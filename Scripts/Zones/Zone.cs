using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Zone : MonoBehaviour
{
    //==========// METHODS //==========//

    public Zone()
    {
    }

    /// <summary>
    /// Checks if the given position is respecting the zone's condition (i.e. whether the position is in the zone)
    /// </summary>
    /// <param name="position">Position to check</param>
    /// <returns>true if the position belongs to the zone, false otherwise</returns>
    public abstract bool IsInZone(Vector3 position);

    /// <summary>
    /// Projects the given vector for it to be comparable to the zone (for example on the axis or the plane of the zone)
    /// </summary>
    /// <param name="position">vector to project</param>
    /// <returns>projection on the vector</returns>
    public abstract Vector3 ProjectOnZoneSpace(Vector3 position);
}

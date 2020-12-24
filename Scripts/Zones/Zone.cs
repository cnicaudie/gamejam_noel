using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Zone : MonoBehaviour
{
    public Zone()
    {
    }

    public abstract bool IsInZone(Vector3 position);

    /// <summary>
    /// Projects the given vector for it to be comparable to the zone (for example on the axis or the plane of the zone)
    /// </summary>
    /// <param name="position">vector to project</param>
    /// <returns>projection on the vector</returns>
    public abstract Vector3 ProjectOnZoneSpace(Vector3 position);
}

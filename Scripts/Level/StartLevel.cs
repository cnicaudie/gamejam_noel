using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevel : MonoBehaviour
{
    //==========// METHODS //==========//

    /// <summary>
    /// Gets the start position of the current level
    /// </summary>
    /// <returns>A Vector3 corresponding to this position</returns>
    public Vector3 GetStartPosition()
    {
        return transform.position;
    }
}

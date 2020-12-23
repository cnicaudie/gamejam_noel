using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float m_actionRange = 6;    

    //==========// METHODS //==========//

    private void Update()
    {
        // Press space to turn on/off a light ball
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Light();
        }

        if (Input.GetKey(KeyCode.Mouse1))
        {
            Drag();
        }
    }

    private void Light()
    {
        MobileLight mobileLight = getClosestLight();

        if (IsInActionRange(mobileLight.gameObject))
        {
            mobileLight.toggleLight();
        }
    }

    private void Drag()
    {
        MobileLight mobileLight = getClosestLight();

        if (IsInActionRange(mobileLight.gameObject))
        {
            Debug.Log("Drag input detected and mobile light found");
            mobileLight.dragTowards(this.transform.position);
        }
    }

    public MobileLight getClosestLight()
    {
        float minDist = Mathf.Infinity;
        MobileLight closestLight = null;

        foreach (MobileLight moblight in FindObjectsOfType<MobileLight>())
        {
            float dist = (moblight.transform.position - transform.position).magnitude;

            if(dist < minDist)
            {
                minDist = dist;
                closestLight = moblight;
            }
        }

        return closestLight;
    }

    public bool IsInActionRange(GameObject go)
    {
        float dist = (go.transform.position - transform.position).magnitude;
        return dist < m_actionRange;
    }
}

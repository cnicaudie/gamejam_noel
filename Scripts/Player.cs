using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //==========// ATTRIBUTES //==========//

    // PRIVATE
    private float m_actionRange = 6;

    // PROPERTIES
    [SerializeField]
    private float m_speed = 10f;
    public float m_Speed
    {
        get { return m_speed; }
        set { m_speed = value; }
    }

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
            //Debug.Log("Drag input detected and mobile light found");

            m_Speed = 5f; // when the player is dragging, he slows a bit down
            mobileLight.dragTowards(this.transform.position);
        }
        else
        {
            m_Speed = 10f; // as soon as he can't drag, he gets its speed back
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

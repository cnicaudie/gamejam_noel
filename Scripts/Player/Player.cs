using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //==========// ATTRIBUTES //==========//

    // PRIVATE
    private float m_actionRange = 3;
    private bool m_resetingTeleport = false;

    [SerializeField]
    private bool m_isDragging = false;

    // PROPERTIES
    [SerializeField]
    private float m_speed = 10f;
    public float m_Speed
    {
        get { return m_speed; }
        set { m_speed = value; }
    }

    [SerializeField]
    private bool m_canTeleport = true;
    public bool m_CanTeleport
    {
        get { return m_canTeleport; }
        set { m_canTeleport = value; }
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
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            m_isDragging = false;
        }

        if (!m_canTeleport && !m_resetingTeleport)
        {
            m_resetingTeleport = true;
            StartCoroutine("resetTeleport");
        }

        if (m_isDragging)
        {
            m_Speed = 5f; // when the player is dragging, he slows a bit down
        } else
        {
            m_Speed = 10f; // as soon as he can't drag, he gets its speed back
        }
    }

    public bool IsInActionRange(GameObject go)
    {
        float dist = (go.transform.position - transform.position).magnitude;
        return dist < m_actionRange;
    }

    private void Light()
    {
        MobileLight mobileLight = GetClosestLight();

        if (IsInActionRange(mobileLight.gameObject))
        {
            mobileLight.ToggleLight();
        }
    }

    private void Drag()
    {
        MobileLight mobileLight = GetClosestLight();

        if (IsInActionRange(mobileLight.gameObject))
        {
            //Debug.Log("Drag input detected and mobile light found");

            m_isDragging = true;
            mobileLight.DragTowards(this.transform.position);
        }
        else
        {
            m_isDragging = false;
        }
    }

    private MobileLight GetClosestLight()
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

    private IEnumerator resetTeleport()
    {
        Debug.Log("Reseting teleportation...");
        yield return new WaitForSeconds(5f);
        Debug.Log("Teleportation has been reset !");
        m_resetingTeleport = false;
        m_canTeleport = true;
    }

}

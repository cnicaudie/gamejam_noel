using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //==========// ATTRIBUTES //==========//

    // PUBLIC
    public static Player m_instance; // singleton instance

    // PRIVATE
    private float m_actionRange = 5;
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

    public bool IsAlive { get; set; }

    //==========// METHODS //==========//

    void Awake()
    {
        MakePlayerSingleton();
    }

    private void Start()
    {
        IsAlive = true;
    }

    void Update()
    {
        if (IsAlive)
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
            }
            else
            {
                m_Speed = 10f; // as soon as he doesn't drag, he gets its speed back
            }
        }
    }

    /// <summary>
    /// Makes sure the Player is a singleton in the whole game
    /// </summary>
    private void MakePlayerSingleton()
    {
        if (m_instance != null)
        {
            Destroy(gameObject); // if there is a second instance, we delete it
        }
        else
        {
            m_instance = this;
            DontDestroyOnLoad(gameObject); // we keep the instance through each scene
        }
    }

    /// <summary>
    /// Checks if the the GameObject in parameter is in the action range of the player
    /// </summary>
    /// <param name="go">The GameObject to interact with</param>
    /// <returns>A boolean telling if the player can interact with the GameObject in parameter</returns>
    public bool IsInActionRange(GameObject go)
    {
        float dist = (go.transform.position - transform.position).magnitude;
        return dist < m_actionRange;
    }

    /// <summary>
    /// Sets the player position to the respawn position (start position of the current scene)
    /// </summary>
    public void SetToBasePosition()
    {
        Vector3 basePosition = FindObjectOfType<StartLevel>().GetStartPosition();
        Vector3 offset = new Vector3(0f, 5f, 0f);
        transform.position = basePosition + offset;
    }

    /// <summary>
    /// [ACTION] Turn on a light if in action range of the player
    /// </summary>
    private void Light()
    {
        MobileLight mobileLight = GetClosestLight();

        if (IsInActionRange(mobileLight.gameObject))
        {
            mobileLight.ToggleLight();
        }
    }

    /// <summary>
    /// [ACTION] Drag an object whithin the zone limits (only lights for now)
    /// </summary>
    private void Drag()
    {
        MobileLight mobileLight = GetClosestLight();

        if (IsInActionRange(mobileLight.gameObject))
        {
            m_isDragging = true;
            mobileLight.DragTowards(transform.position);
        }
        else
        {
            m_isDragging = false;
        }
    }

    /// <summary>
    /// Checks if there are lights around the player
    /// </summary>
    /// <returns>The closest light</returns>
    private MobileLight GetClosestLight()
    {
        float minDist = Mathf.Infinity;
        MobileLight closestLight = null;

        foreach (MobileLight moblight in FindObjectsOfType<MobileLight>())
        {
            float dist = (moblight.transform.position - transform.position).magnitude;

            if (dist < minDist)
            {
                minDist = dist;
                closestLight = moblight;
            }
        }

        return closestLight;
    }

    /// <summary>
    /// Coroutine to reset the teleport capability of the player (avoiding infinite teleportation)
    /// </summary>
    /// <returns></returns>
    private IEnumerator resetTeleport()
    {
        Debug.Log("Reseting teleportation...");
        yield return new WaitForSeconds(5f);
        Debug.Log("Teleportation has been reset !");
        m_resetingTeleport = false;
        m_canTeleport = true;
    }

}

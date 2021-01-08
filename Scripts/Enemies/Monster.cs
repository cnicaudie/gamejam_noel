﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    Player m_player;
    [SerializeField]
    float m_viewRange;
    [SerializeField]
    float m_actionRange;
    NavMeshAgent m_agent;
    Vector3 m_startPos;
    Quaternion m_startRot;
    float m_timer;
    float m_patience;

    public GameObject attackEffect;

    // Start is called before the first frame update
    void Start()
    {
        m_startPos = transform.position;
        m_startRot = transform.rotation;
        m_player = FindObjectOfType<Player>();
        m_viewRange = 50;
        m_actionRange = 3;
        m_agent = GetComponent<NavMeshAgent>();
        m_patience = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayerInActionRange())
        {
            attack();
        }
    }

    private void FixedUpdate()
    {
        // Setting destination according 
        if (isPlayerInLOS())
        {
            m_agent.SetDestination(m_player.transform.position);

        }else if(m_agent.velocity.magnitude <= 0.01)
        {
            m_agent.SetDestination(m_startPos);
        }

        // Reset timer if there is a path to destination
        if (m_agent.pathStatus == NavMeshPathStatus.PathComplete) m_timer = 0;

        // Timer update 
        m_timer += Time.fixedDeltaTime;

        // Reset timer and go back to startPos if beyond patience 
        if(m_timer > m_patience)
        {
            m_timer = 0;
            m_agent.SetDestination(m_startPos);
        }

        // Resting rotation after returning to start position
        if (m_agent.destination.x == m_startPos.x && m_agent.destination.z == m_startPos.z && m_agent.remainingDistance < 0.1f)
        {
            var temp = m_agent.angularSpeed;
            m_agent.angularSpeed = 0;
            m_agent.transform.rotation = Quaternion.RotateTowards(transform.rotation, m_startRot, 1.0f);
            m_agent.angularSpeed = temp;
        }

        if (m_agent.destination.x==m_player.transform.position.x && m_agent.destination.z == m_player.transform.position.z)
        {
            m_agent.stoppingDistance = m_actionRange;
        }else
        {
            m_agent.stoppingDistance = 0;
        }

        //Debug.Log("Velocity : " + m_agent.velocity.magnitude);
        //Debug.Log("PathSatus : " + m_agent.pathStatus);
    }

    public bool isPlayerInLOS()
    {
        // Get player position
        Vector3 playerPos = m_player.transform.position;

        // Cast a ray towards player and check if we collide player
        RaycastHit hitInfo;

        if (Physics.Raycast(transform.position, (playerPos - transform.position), out hitInfo, m_viewRange))
        {
            Player player = hitInfo.collider.GetComponent<Player>();

            float angle = Vector3.Angle((playerPos - transform.position).normalized, transform.forward);

            if (player != null && Mathf.Abs(angle) < 45.0f)
            {
                Debug.DrawRay(transform.position, (playerPos - transform.position).normalized * hitInfo.distance, Color.green);
                return true;
            }
            else
            {
                Debug.DrawRay(transform.position, (playerPos - transform.position).normalized * hitInfo.distance, Color.yellow);
                return false;
            }
        }
        else
        {
            Debug.DrawRay(transform.position, (playerPos - transform.position).normalized * 1000, Color.red);
            Debug.Log("Did not Hit");
            return false;
        }
    }

    public bool isPlayerInActionRange()
    {
        // Get player position
        Vector2 playerPos = new Vector2(m_player.transform.position.x, m_player.transform.position.z);
        Vector2 monsterPos = new Vector2(transform.position.x, transform.position.z);
        

        float distance = (playerPos - monsterPos).magnitude;

        return distance <= m_actionRange;
    }

    public void attack()
    {
        if(isPlayerInActionRange() && m_player.IsAlive)
        {
            StartCoroutine(KillPlayer());
        }
        m_agent.velocity = Vector3.zero;
    }

    public IEnumerator KillPlayer()
    {
        m_player.IsAlive = false;
        var temp = m_player.m_Speed;
        m_player.m_Speed = 0;
        StartCoroutine(KillAnimation(1.5f, 1.0f, 4.0f));
        yield return new WaitForSeconds(1.5f);
        m_player.m_Speed = temp;
        m_player.SetToBasePosition();
        m_player.IsAlive = true;
    }

    public IEnumerator KillAnimation(float time, float startingScale, float endScale)
    {
        GameObject effect = Instantiate(attackEffect, m_player.transform.position, Quaternion.identity);
        effect.transform.localScale = new Vector3(startingScale, startingScale, startingScale);
        float timer = 0;

        while (timer < time)
        {
            float currentScale = Mathf.Lerp(startingScale, endScale, timer);
            effect.transform.localScale = new Vector3(currentScale, currentScale, currentScale);
            timer += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        GameObject.Destroy(effect);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLevel : MonoBehaviour
{
    //==========// ATTRIBUTES //==========//

    // GAME MANAGER
    private GameManager m_gameManager;

    //==========// METHODS //==========//

    void Awake()
    {
        m_gameManager = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name + " has found the exit !");
        m_gameManager.HasLevelEnded = true;
    }
}

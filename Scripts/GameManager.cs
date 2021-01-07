using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //==========// ATTRIBUTES //==========//

    // PUBLIC
    public static GameManager m_instance; // singleton instance

    // PRIVATE
    private Player m_player;

    // PROPERTIES
    [SerializeField] private bool m_hasLevelEnded = false;
    public bool m_HasLevelEnded {
        get { return m_hasLevelEnded; }
        set { m_hasLevelEnded = value; }
    }

    //==========// METHODS //==========//

    void Awake()
    {
        MakeGameSingleton();

        m_player = FindObjectOfType<Player>();
        m_player.SetToBasePosition();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_HasLevelEnded)
        {
            LoadNextLevel();
        }
    }

    /// <summary>
    /// Makes sure the GameManager is a singleton in the whole game
    /// </summary>
    private void MakeGameSingleton()
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
    /// Loads the next level in the build settings
    /// </summary>
    private void LoadNextLevel()
    {
        Debug.Log("Loading next level...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); 
        // Change for the following line when new levels will be implemented 
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log(SceneManager.GetActiveScene().name + " was successfully loaded !");

        m_HasLevelEnded = false;
        m_player.SetToBasePosition();
    }
}

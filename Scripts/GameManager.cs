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

    private bool m_isInMenu = true;

    // true : we play one level (and then back to menu)
    // false : we play every levels 
    private bool m_levelMode = true; 

    //==========// METHODS //==========//

    void Awake()
    {
        MakeGameSingleton();

        if (!m_isInMenu)
        {
            m_player = FindObjectOfType<Player>();
            m_player.SetToBasePosition();
        }
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


    public void StartGame()
    {
        LoadLevel(0); // put 1 later
    }

    public void LevelMenu()
    {
        SceneManager.LoadScene("Level_Menu");
    }

    public void SettingsMenu()
    {
        // TODO
    }

    public void CreditsPage()
    {
        // TODO
    }

    private void LoadLevel(int levelNumber)
    {
        Debug.Log("Loading next level...");

        if (levelNumber == 0)
        {
            SceneManager.LoadScene("TestLevel");
        }
        else
        {
            SceneManager.LoadScene("Level_" + levelNumber);
        }

        Debug.Log(SceneManager.GetActiveScene().name + " was successfully loaded !");

        m_isInMenu = false;
        m_HasLevelEnded = false;
        m_player.SetToBasePosition();
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

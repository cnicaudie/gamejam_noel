using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //==========// ATTRIBUTES //==========//

    // PUBLIC
    public static GameManager s_instance; // singleton instance

    public static bool s_isInMenu = true;
    public const int k_maxLevels = 10;

    // Puzzle mode = we play one level at a time
    // (and then choose a next level from the unlocked ones)
    // If puzzle mode = false, then we play every levels in order
    private bool m_puzzleMode = true;

    // PROPERTIES
    private bool hasLevelEnded = false;
    public bool HasLevelEnded {
        get { return hasLevelEnded; }
        set { hasLevelEnded = value; }
    }

    [SerializeField]
    private int currentLevel = 1;
    public int CurrentLevel
    {
        get { return currentLevel; }
        set { currentLevel = value; }
    }


    //==========// METHODS //==========//

    void Awake()
    {
        MakeGameSingleton();
    }

    // Update is called once per frame
    void Update()
    {
        if (HasLevelEnded)
        {
            if (m_puzzleMode)
            {
                LoadIntermediateMenu();
            }
            else
            {
                LoadNextLevel();
            }
        }

        if (!s_isInMenu && Input.GetKeyDown(KeyCode.M))
        {
            LoadMainMenu();
        }
    }

    /// <summary>
    /// Makes sure the GameManager is a singleton in the whole game
    /// </summary>
    private void MakeGameSingleton()
    {
        if (s_instance != null)
        {
            Destroy(gameObject); // if there is a second instance, we delete it
        }
        else
        {
            s_instance = this;
            DontDestroyOnLoad(gameObject); // we keep the instance through each scene
        }
    }

    /// <summary>
    /// Loads the Main menu scene
    /// </summary>
    public void LoadMainMenu()
    {
        s_isInMenu = true;
        SceneManager.LoadScene("Main_Menu");
    }


    /// <summary>
    /// Loads a level from its name
    /// </summary>
    /// <param name="levelName">Name of the level</param>
    public void LoadLevel(string levelName)
    {
        s_isInMenu = false;
        HasLevelEnded = false;

        Debug.Log("Loading " + levelName + "...");

        SceneManager.LoadScene(levelName);

        Debug.Log(levelName + " was successfully loaded !");
    }

    /// <summary>
    /// Reloads the current level
    /// </summary>
    public void ReloadLevel()
    {
        LoadLevel("Level_" + currentLevel);
    }

    /// <summary>
    /// Loads the next level
    /// </summary>
    public void LoadNextLevel()
    {
        // TODO : Uncomment when we have more levels
        //currentLevel++;
        ReloadLevel();
    }

    /// <summary>
    /// Loads the intermediate menu
    /// </summary>
    private void LoadIntermediateMenu()
    {
        s_isInMenu = true;
        HasLevelEnded = false;
        SceneManager.LoadScene("Intermediate_Menu");
    }
}

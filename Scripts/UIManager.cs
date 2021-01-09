using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    //==========// ATTRIBUTES //==========//

    // PRIVATE
    private GameManager m_gameManager;

    [SerializeField] private GameObject m_mainMenu;
    [SerializeField] private GameObject m_levelMenu;

    //==========// METHODS //==========//

    void Awake()
    {
        m_gameManager = FindObjectOfType<GameManager>();
    }

    public void StartGame()
    {
        // TODO : Uncomment the next line when we stop the test phase
        //puzzleMode = false;

        GameManager.s_isInMenu = false;
        m_gameManager.CurrentLevel = 1;
        m_gameManager.LoadLevel("Level_1");
    }

    /// <summary>
    /// Displays the main menu
    /// </summary>
    public void LevelMenu()
    {
        GameManager.s_isInMenu = true;
        SceneManager.LoadScene("Level_Menu");
    }

    /// <summary>
    /// Displays the settings menu
    /// </summary>
    public void SettingsMenu()
    {
        // TODO
    }

    /// <summary>
    /// Displays the credits page
    /// </summary>
    public void CreditsPage()
    {
        // TODO
    }

    /// <summary>
    /// Displays the main menu
    /// </summary>
    public void MainMenu()
    {
        GameManager.s_isInMenu = true;
        SceneManager.LoadScene("Main_Menu");
    }

    /// <summary>
    /// Loads the just played level
    /// </summary>
    public void TryAgain()
    {
        m_gameManager.ReloadLevel();
    }

    /// <summary>
    /// Loads the next level
    /// </summary>
    public void NextLevel()
    {
        m_gameManager.LoadNextLevel();
    }
}

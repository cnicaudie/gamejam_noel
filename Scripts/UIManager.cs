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
        m_gameManager.LoadLevel("TestLevel"); // TODO : To change for "Level_1"
    }

    /// <summary>
    /// Method to display the main menu
    /// </summary>
    public void LevelMenu()
    {
        GameManager.s_isInMenu = true;
        SceneManager.LoadScene("Level_Menu");
    }

    /// <summary>
    /// Method to display the settings menu
    /// </summary>
    public void SettingsMenu()
    {
        // TODO
    }

    /// <summary>
    /// Method to display the credits page
    /// </summary>
    public void CreditsPage()
    {
        // TODO
    }

    /// <summary>
    /// Method to display the main menu
    /// </summary>
    public void MainMenu()
    {
        GameManager.s_isInMenu = true;
        SceneManager.LoadScene("Main_Menu");
    }

}

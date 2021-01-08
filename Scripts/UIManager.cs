using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    private GameManager m_gameManager;

    // UI
    [SerializeField] private GameObject m_mainMenu;
    [SerializeField] private GameObject m_levelMenu;

    void Awake()
    {
        m_gameManager = FindObjectOfType<GameManager>();
    }

    public void StartGame()
    {
        // TODO : Uncomment the next line when we stop the test phase
        //puzzleMode = false;

        m_gameManager.LoadLevel("TestLevel"); // TODO : To change for "Level_1"
    }

    public void LevelMenu()
    {
        GameManager.s_isInMenu = true;
        //SceneManager.LoadScene("Level_Menu");

        m_mainMenu.SetActive(false);
        m_levelMenu.SetActive(true);
    }

    public void SettingsMenu()
    {
        // TODO
    }

    public void CreditsPage()
    {
        // TODO
    }

    public void MainMenu()
    {
        //SceneManager.LoadScene("Main_Menu");

        m_levelMenu.SetActive(false);
        m_mainMenu.SetActive(true);
    }

    
}

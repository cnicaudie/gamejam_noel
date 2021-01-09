using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UILevelButton : MonoBehaviour
{

    [SerializeField]
    private Button m_button;

    [SerializeField]
    private TextMeshProUGUI m_buttonText;

    private GameManager m_gameManager;

    private void Awake()
    {
        m_button = GetComponent<Button>();
        m_button.onClick.AddListener(OnClick);

        m_buttonText = GetComponentInChildren<TextMeshProUGUI>();

        m_gameManager = FindObjectOfType<GameManager>();

    }

    private void Update()
    {
        if (m_button.transform.GetSiblingIndex() >= m_gameManager.CurrentLevel + 1)
        {
            m_button.interactable = false;
        }
    }

    void OnClick()
    {
        m_gameManager.LoadLevel(m_button.name);
        m_gameManager.CurrentLevel = m_button.transform.GetSiblingIndex() + 1;
    }

    public void SetText(string s)
    {
        m_buttonText.text = s;
    }

}

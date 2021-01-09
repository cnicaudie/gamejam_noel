using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILevels : MonoBehaviour
{
    //==========// ATTRIBUTES //==========//

    // PRIVATE
    [SerializeField] private GameObject m_buttonTemplate;

    //==========// METHODS //==========//

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 2; i <= GameManager.k_maxLevels; i++)
        {
            InstantiateNewButton("Level_" + i, "LEVEL " + i, i - 1);
        }
    }

    /// <summary>
    /// Instantiates a new button based on the template button
    /// </summary>
    /// <param name="buttonName">Name of the button's Game Object</param>
    /// <param name="buttonText">Text of the button</param>
    /// <param name="index">Index of the button</param>
    private void InstantiateNewButton(string buttonName, string buttonText, int index)
    {
        GameObject button = Instantiate(m_buttonTemplate) as GameObject;
        button.transform.SetSiblingIndex(index);
        button.SetActive(true);
        button.name = buttonName;
        button.GetComponentInChildren<UILevelButton>().SetText(buttonText);
        button.transform.SetParent(m_buttonTemplate.transform.parent, false);
    }
}

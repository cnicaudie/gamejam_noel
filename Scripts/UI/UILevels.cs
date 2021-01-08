using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILevels : MonoBehaviour
{

    [SerializeField]
    private GameObject m_buttonTemplate;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 2; i <= GameManager.k_maxLevels; i++)
        {
            InstantiateNewButton("Level_" + i, "LEVEL " + i, i - 1);
        }
    }

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

using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class DifficultySelectMenu : BaseMenu
{

    public GameObject m_MenuObject;
    public Transform m_DifficultyButtonsAncor;

    public GameObject m_DifficultyButtonPrefab;

    public int m_DefaultBoardSizeX = 4;
    public int m_DefaultBoardSizeY = 4;

    public List<DifficultySetting> m_difficulties;

    private Transform _menuObjectTransform;
    private bool _UiCreated = false;

    void Start()
    {
        _menuObjectTransform = m_MenuObject.transform;
        PlayerPrefs.SetInt("boardSizeX", m_DefaultBoardSizeX);
        PlayerPrefs.SetInt("boardSizeY", m_DefaultBoardSizeY);
    }

    public override void DisplayMenu()
    {
        m_MenuObject.SetActive(true);
        if (!_UiCreated)
        {
            CreateDifficultyButtons();
            _UiCreated = true;
        }
    }

    public override void HideMenu()
    {
        m_MenuObject.SetActive(false);
    }

    private void CreateDifficultyButtons()
    {
        Vector2 buttonPosition = m_DifficultyButtonsAncor.position;


        for (int i = 0; i < m_difficulties.Count; i++)
        {
            GameObject go = (GameObject)Instantiate(m_DifficultyButtonPrefab, buttonPosition, Quaternion.identity);
            buttonPosition.y -= 40;

            go.transform.SetParent(_menuObjectTransform, true);
            go.transform.localScale = Vector3.one;
            DifficultyButton db = go.GetComponent<DifficultyButton>();
            db.Setting = m_difficulties[i];
            db._menu = this;
        }
    }
}

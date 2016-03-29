using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class DifficultyButton : BaseButton
{

    public Text m_buttonLabel;
    private DifficultySetting m_DifficultySetting;
    
    public DifficultySetting Setting
    {
        set
        {
            m_DifficultySetting = value;
            SetDifficultyDisplayName(m_DifficultySetting.difficultyName);
        }
        get
        {
            return m_DifficultySetting;
        }
    }

    public override void ButtonPressed()
    {
        PlayerPrefs.SetInt("boardSizeX", m_DifficultySetting.boardSizeX);
        PlayerPrefs.SetInt("boardSizeY", m_DifficultySetting.boardSizeY);
        PlayerPrefs.SetFloat("spawnTimer", m_DifficultySetting.spawnTimer);
        _menu.ChangeMenu(MenuTypes.START);
    }

    public void SetDifficultyDisplayName(string name)
    {
        m_buttonLabel.text = m_DifficultySetting.difficultyName;
    }



}

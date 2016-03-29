using UnityEngine;
using System.Collections;
using System;

public class SpashMenu : BaseMenu
{
    public GameObject m_SpashMenu;
    //public float m_FadeOutSpeed = 1f;
    public float m_DisplayTTL = 2f;

    public MenuTypes m_NextMenuType;

    private bool _isActive = false;
    private float _ttlCounter = 0f;

    public override void DisplayMenu()
    {
        m_SpashMenu.SetActive(true);
        _isActive = true;
    }

    public override void HideMenu()
    {
        m_SpashMenu.SetActive(false);
        _isActive = false;
    }

    void Update()
    {
        if (_isActive)
        {
            _ttlCounter += Time.deltaTime;
            if (_ttlCounter > m_DisplayTTL)
            {
                ChangeMenu(m_NextMenuType);
            }
        }
    }







}

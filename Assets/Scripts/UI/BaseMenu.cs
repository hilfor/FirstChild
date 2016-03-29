using UnityEngine;
using System;
[Serializable]
public abstract class BaseMenu : MonoBehaviour
{
    
    [SerializeField]
    public MenuTypes _menuType;

    public MenusController _MenusController;

    public void ChangeMenu(MenuTypes menuType)
    {
        _MenusController.ChangeMenu(menuType);
    }

    public void BackButtonPressed()
    {
        _MenusController.BackButtonPressed();
    }

    public abstract void DisplayMenu();
    public abstract void HideMenu();
    



}

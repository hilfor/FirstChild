using UnityEngine;
using System.Collections;

public abstract class BaseMenu : MonoBehaviour
{

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

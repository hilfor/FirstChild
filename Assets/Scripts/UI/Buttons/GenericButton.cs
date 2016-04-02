using UnityEngine;
using System.Collections;
using System;

public class GenericButton : BaseButton
{
    public MenuTypes MenuTypeDestination;
    public override void ButtonPressed()
    {
        _menu.ChangeMenu(MenuTypeDestination);
    }
}

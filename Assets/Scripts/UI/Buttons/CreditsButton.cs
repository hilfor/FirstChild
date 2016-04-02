using UnityEngine;
using System.Collections;
using System;

public class CreditsButton : BaseButton
{
    public override void ButtonPressed()
    {
        _menu.ChangeMenu(MenuTypes.ABOUT);
    }
}

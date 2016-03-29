using UnityEngine;
using System.Collections;

public class StartButton : BaseButton
{

    public override void ButtonPressed()
    {
        _menu.ChangeMenu(MenuTypes.DIFFICULTY);
    }
}

﻿using UnityEngine;
using System.Collections;
using System;

public class QuitButton : BaseButton
{
    public override void ButtonPressed()
    {
        Application.Quit();
    }
}

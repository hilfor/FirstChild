using UnityEngine;
using System.Collections;
using System;

public class BabyBomb : BombManager
{

    public override BombType GetBombType()
    {
        return BombType.BABY;
    }

    public override void ShowBomb()
    {
        throw new NotImplementedException();
    }

}

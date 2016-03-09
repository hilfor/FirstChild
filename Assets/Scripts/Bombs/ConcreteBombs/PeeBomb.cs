using UnityEngine;
using System.Collections;
using System;

public class PeeBomb : BombManager
{
    public override BombType GetBombType()
    {
        return BombType.PEE;
    }

    public override void ShowBomb()
    {
        throw new NotImplementedException();
    }

}

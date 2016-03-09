using System;

public class PoopBomb : BombManager
{
    public override BombType GetBombType()
    {
        return BombType.POOP;
    }

    public override void ShowBomb()
    {
        throw new NotImplementedException();
    }

}

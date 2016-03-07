using UnityEngine;
using System.Collections;
using System;

public class PoopBomb : BombManager
{
    public override void DeployBombExplosion()
    {
        if (_BombDestroyAnimation)
            Instantiate(_BombDestroyAnimation, transform.position, Quaternion.identity);
    }

    public override BombType GetBombType()
    {
        return BombType.POOP;
    }

    public override void HideBomb()
    {
        Destroy(gameObject);
    }

    public override void ShowBomb()
    {
        throw new NotImplementedException();
    }

    public override void UpdateScore(ScoreManager scoreManager)
    {
        scoreManager.UpdateScore(_Score);
    }
}

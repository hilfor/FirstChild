using UnityEngine;
using System.Collections;
using System;

public class BabyBomb : BombManager
{
    public override void BombClicked()
    {
        UpdateScore(-_Score);
        _LifeManager.DecreaseLife();
    }

    public override BombType GetBombType()
    {
        return BombType.BABY_BOY;
    }

    public override void OnBombTimerDone()
    {
        if (_Animator)
            _Animator.SetTrigger("TimedOut");
        UpdateScore(_Score);
    }

    public override void ShowBomb()
    {
        throw new NotImplementedException();
    }

    public override void UpdateScore(int score)
    {
        _ScoreManager.UpdateScore(score);
    }
}


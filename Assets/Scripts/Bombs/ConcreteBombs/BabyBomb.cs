using UnityEngine;
using System.Collections;
using System;

public class BabyBomb : BombManager
{

    public override BombType GetBombType()
    {
        return BombType.BABY;
    }

    public override void OnBombTimerDone()
    {
        if (_Animator)
            _Animator.SetTrigger("TimedOut");
        UpdateScore(-_Score);
        //HideBomb();
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

using System;

public class PoopBomb : BombManager
{
    public override BombType GetBombType()
    {
        return BombType.POOP;
    }

    public override void OnBombTimerDone()
    {
        if (_Animator)
            _Animator.SetTrigger("TimedOut");
        UpdateScore(-_Score);
        _LifeManager.DecreaseLife();
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

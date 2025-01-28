using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    private MonsterData _currentMonster = null;
    private string _currentAnimation = string.Empty;

    public void Awake()
    {
        _currentMonster = GetComponentInChildren<MonsterData>();
    }

    public int GetCurrentMonsterSpeed()
    {
        int monsterSpeed = 0;
        if (_currentMonster != null)
        {
            monsterSpeed = _currentMonster.Speed;
        }
        return monsterSpeed;
    }

    public void SetAnimation(short moveValue)
    {
        if (_currentMonster != null)
        {
            if ((moveValue != 0) && (_currentAnimation != _currentMonster.MoveAnimationKey))
            {
                _currentAnimation = _currentMonster.MoveAnimationKey;
                _currentMonster.MonsterAnimator.SetTrigger(_currentAnimation);
            }
            else if ((moveValue == 0) && (_currentAnimation != _currentMonster.IdleAnimationKey))
            {
                _currentAnimation = _currentMonster.IdleAnimationKey;
                _currentMonster.MonsterAnimator.SetTrigger(_currentAnimation);
            }
        }
    }
}

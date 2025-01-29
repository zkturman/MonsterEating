using System.Collections;
using System.Collections.Generic;
using System.Reflection;
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

    public void EatFood(FoodData foodToEat)
    {
        if (_currentMonster != null)
        {
            _currentMonster.MonsterConsumer.ConsumeFood(foodToEat);
            bool canEvolve = _currentMonster.MonsterConsumer.EvolutionVoter.RequiredCountMet();
            SoundEffectKey soundEffect = SoundEffectKey.Eat;
            if (foodToEat.FoodKey == FoodKey.Deadlie)
            {
                soundEffect = SoundEffectKey.Die;
            }
            else if (canEvolve)
            {
                EvolveMonster();
            }
            SoundEffectManager.PlayEffect(soundEffect);
        }
    }

    public void EvolveMonster()
    {
        MonsterKey nextMonsterKey = _currentMonster.MonsterConsumer.EvolutionVoter.FindWinner();
        Destroy(_currentMonster.gameObject);
        GameObject nextMonsterPrefab = MonsterManager.GetMonsterPrefab(nextMonsterKey);
        GameObject newMonster = Instantiate(nextMonsterPrefab, this.transform.position, Quaternion.identity);
        newMonster.transform.SetParent(this.transform, true);
        _currentMonster = newMonster.GetComponent<MonsterData>();
        _currentAnimation = string.Empty;
        SoundEffectManager.PlayEffect(SoundEffectKey.Evolve);
    }

    public void GameOver()
    {

    }
}

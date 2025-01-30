using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    [SerializeField]
    private GameObject _evolveEffectPrefab;
    [SerializeField]
    private GameObject _deathEffectPrefab;
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
            bool couldEatFood = _currentMonster.MonsterConsumer.ConsumeFood(foodToEat);
            bool canEvolve = _currentMonster.MonsterConsumer.EvolutionVoter.RequiredCountMet();
            if (foodToEat.FoodKey == FoodKey.Deadlie)
            {
                GameOver();
            }
            else if (canEvolve)
            {
                EvolveMonster();
            }
            else if (couldEatFood)
            {
                SoundEffectManager.PlayEffect(SoundEffectKey.Eat);
            }
            else
            {
                SoundEffectManager.PlayEffect(SoundEffectKey.BadEat);
            }
        }
    }

    public void EvolveMonster()
    {
        StartCoroutine(evolveRoutine());
    }

    private IEnumerator evolveRoutine()
    {
        MonsterKey nextMonsterKey = _currentMonster.MonsterConsumer.EvolutionVoter.FindWinner();
        Destroy(_currentMonster.gameObject);
        _currentMonster = null;
        Instantiate(_evolveEffectPrefab, this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        GameObject nextMonsterPrefab = MonsterManager.GetMonsterPrefab(nextMonsterKey);
        GameObject newMonster = Instantiate(nextMonsterPrefab, this.transform);
        newMonster.transform.position = this.transform.position;
        _currentMonster = newMonster.GetComponent<MonsterData>();
        _currentAnimation = string.Empty;
        SaveManager.SaveMonster(nextMonsterKey);
        SoundEffectManager.PlayEffect(SoundEffectKey.Evolve);
    }

    public void GameOver()
    {
        StartCoroutine(deathRoutine());
    }

    private IEnumerator deathRoutine()
    {
        if (_currentMonster != null)
        {
            SoundEffectManager.PlayEffect(SoundEffectKey.Die);
            _currentMonster.MonsterAnimator.SetTrigger(_currentMonster.DieAnimationKey);
            float timeToWaitInSeconds = _currentMonster.DieAnimationTimeInSeconds;
            _currentMonster = null;
            Instantiate(_deathEffectPrefab, this.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(timeToWaitInSeconds + 1);
            this.transform.SetParent(null);
            DontDestroyOnLoad(this.gameObject);
            SceneManager.OpenScene("GameOverMenu");
        }
    }

    public float GetEvolutionPercentage()
    {
        float currentPercent = -1f;
        if (_currentMonster != null)
        {
            float totalAte = _currentMonster.MonsterConsumer.EvolutionVoter.GetCurrentTotal();
            float requiredAmount = _currentMonster.MonsterConsumer.EvolutionVoter.RequiredCount;
            currentPercent = totalAte / requiredAmount;
        }
        return currentPercent;
    }
}

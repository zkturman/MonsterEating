using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EvolutionData : MonoBehaviour
{
    [SerializeField]
    private MonsterKey[] evolutionChoices;
    private Dictionary<MonsterKey, int> _choiceVoting;
    [SerializeField]
    private int _requiredCount = 10;
    public int RequiredCount { get => _requiredCount; }

    private void Awake()
    {
        _choiceVoting = evolutionChoices.ToDictionary(x => x, x => 0);
    }

    public void VoteChoice(MonsterKey choiceToLog)
    {
        _choiceVoting[choiceToLog]++;
    }

    public MonsterKey FindWinner()
    {
        return _choiceVoting.OrderByDescending(x => x.Value).First().Key;
    }

    public int GetCurrentTotal()
    {
        return _choiceVoting.Sum(x => x.Value);
    }

    public bool RequiredCountMet()
    {
        return GetCurrentTotal() == _requiredCount;
    }
}

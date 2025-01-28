using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EvolutionData : MonoBehaviour
{
    [SerializeField]
    private MonsterKey[] evolutionChoices;
    private Dictionary<MonsterKey, int> _choiceVoting;
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
        return _choiceVoting.Max(x => x.Key);
    }
}

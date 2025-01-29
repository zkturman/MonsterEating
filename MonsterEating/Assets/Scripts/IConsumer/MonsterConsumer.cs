using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MonsterConsumer : MonoBehaviour, IFoodConsumer
{
    [SerializeField]
    private MonsterFoodKeyPair[] _evolutions;
    private Dictionary<FoodKey, MonsterKey> _foodMonsterMap;
    [SerializeField]
    private EvolutionData _evolutionVoter;
    public EvolutionData EvolutionVoter { get; private set; }

    private void Awake()
    {
        EvolutionVoter = _evolutionVoter;
        _foodMonsterMap = _evolutions.ToDictionary(x => x.RequiredFood, x => x.Evolution);
    }

    public void ConsumeFood(FoodData foodToEat)
    {
        if (_foodMonsterMap.ContainsKey(foodToEat.FoodKey))
        {
            MonsterKey nextMonster = _foodMonsterMap[foodToEat.FoodKey];
            EvolutionVoter.VoteChoice(nextMonster);
        }
        Destroy(foodToEat.gameObject);
    }
}
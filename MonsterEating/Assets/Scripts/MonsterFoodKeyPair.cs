using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MonsterFoodKeyPair 
{
    [SerializeField]
    private MonsterKey _evolution;
    public MonsterKey Evolution { get => _evolution; }
    [SerializeField]
    public FoodKey _requiredFood;
    public FoodKey RequiredFood { get => _requiredFood; }

}

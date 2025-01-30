using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFoodConsumer
{
    public EvolutionData EvolutionVoter { get; }
    public bool ConsumeFood(FoodData foodToEat);
}

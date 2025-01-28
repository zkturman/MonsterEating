using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFoodConsumer
{
    public EvolutionData EvolutionVoter { get; }
    public void ConsumeFood(FoodKey foodToEat);
}

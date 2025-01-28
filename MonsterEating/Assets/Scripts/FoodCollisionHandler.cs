using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCollisionHandler : MonoBehaviour
{
    [SerializeField]
    private FoodData _foodInfo;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out MonsterConsumer monster))
        {
            monster.ConsumeFood(_foodInfo);
            Debug.Log("Eat food and stuff.");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodData : MonoBehaviour
{
    [SerializeField]
    private string _foodName;
    public string FoodName { get => _foodName; }
    [SerializeField]
    private FoodKey _foodKey;
    public FoodKey FoodKey { get => _foodKey; }
    [SerializeField]
    private GameObject _destroyEffect;
    public GameObject DestroyEffect { get => _destroyEffect; }
}

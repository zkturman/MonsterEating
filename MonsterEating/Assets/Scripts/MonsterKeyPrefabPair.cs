using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MonsterKeyPrefabPair
{
    [SerializeField]
    private MonsterKey _key;
    public MonsterKey Key { get => _key; }
    [SerializeField]
    private GameObject _prefab;
    public GameObject Prefab { get => _prefab; }
}

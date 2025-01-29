using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MonsterManager : MonoBehaviour
{
    [SerializeField]
    private MonsterKeyPrefabPair[] _allMonsters;
    private Dictionary<MonsterKey, GameObject> _monsterKeyMap;
    private static MonsterManager _instance;
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        _monsterKeyMap = _allMonsters.ToDictionary(x => x.Key, x => x.Prefab);
    }
    public static GameObject GetMonsterPrefab(MonsterKey monsterToFind)
    {
        GameObject foundMonster = null;
        if (_instance._monsterKeyMap.ContainsKey(monsterToFind))
        {
            foundMonster = _instance._monsterKeyMap[monsterToFind];
        }
        return foundMonster;
    }
}

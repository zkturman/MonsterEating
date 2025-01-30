using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SaveManager: MonoBehaviour
{
    private const string PrefKey = "FoundMonsters";
    private const char PrefSeparator = '|';
    private static HashSet<MonsterKey> _foundMonsters;

    private void Awake()
    {
        LoadFoundMonsters();
        ProgressRevealer revealer = GetComponent<ProgressRevealer>();
        if (revealer != null)
        {
            revealer.enabled = true;
        }
    }

    public static void LoadFoundMonsters()
    {
        _foundMonsters = new HashSet<MonsterKey>();
        if (PlayerPrefs.HasKey(PrefKey))
        {
            string prefValue = PlayerPrefs.GetString(PrefKey);
            string[] monsterValues = prefValue.Split(PrefSeparator);
            for (int i = 0; i < monsterValues.Length; i++)
            {
                if (Enum.TryParse(typeof(MonsterKey), monsterValues[i], out object currentKey))
                {
                    if (!_foundMonsters.Contains((MonsterKey)currentKey))
                    {
                        _foundMonsters.Add((MonsterKey)currentKey);
                    }
                }
            }
        }
    }

    public static void SaveMonster(MonsterKey monsterToSave)
    {
        if (!_foundMonsters.Contains(monsterToSave))
        {
            string prefValue = string.Empty;
            if (PlayerPrefs.HasKey(PrefKey))
            {
                prefValue = PlayerPrefs.GetString(PrefKey);
            }
            prefValue = prefValue + monsterToSave.ToString() + PrefSeparator;
            PlayerPrefs.SetString(PrefKey, prefValue);
        }
    }

    public static List<MonsterKey> GetFoundMonsters()
    {
        return _foundMonsters.ToList();
    }
}

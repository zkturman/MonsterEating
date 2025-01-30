using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressRevealer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        List<MonsterKey> foundMonsters = SaveManager.GetFoundMonsters();
        for (int i = 0; i < foundMonsters.Count; i++)
        {
            MonsterManager.GetMonsterPrefab(foundMonsters[i]).SetActive(true);
        }
    }
}

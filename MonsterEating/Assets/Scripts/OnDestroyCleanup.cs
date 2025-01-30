using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroyCleanup : MonoBehaviour
{
    private MonsterController _deadMonster;
    private void Awake()
    {
        _deadMonster = FindObjectOfType<MonsterController>(true);
    }

    private void OnDestroy()
    {
        if (_deadMonster != null)
        {
            Destroy(_deadMonster.gameObject);
        }
    }
}

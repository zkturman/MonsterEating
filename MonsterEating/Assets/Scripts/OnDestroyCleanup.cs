using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnDestroyCleanup : MonoBehaviour
{
    private void OnDestroy()
    {
        GameObject _deadMonster = FindObjectOfType<MonsterController>().gameObject;
        if (_deadMonster != null)
        {
            Destroy(_deadMonster);
        }
    }
}

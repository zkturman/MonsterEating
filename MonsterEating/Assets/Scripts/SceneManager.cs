using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public static void OpenScene(string sceneName)
    {
        SaveManager.SaveMonster(MonsterKey.Ghost);
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}

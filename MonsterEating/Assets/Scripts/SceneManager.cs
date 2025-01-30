using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SceneManager : MonoBehaviour
{
    [SerializeField]
    private UIDocument _sceneCurtainDocument;
    private VisualElement _rootElement;
    private VisualElement _sceneCurtain;
    [SerializeField]
    private string _fadeTransitionName = "fade-anim";
    private static SceneManager _instance;
    private void OnEnable()
    {
        _rootElement = _sceneCurtainDocument.rootVisualElement;
        _sceneCurtain = _rootElement.Q<VisualElement>("Curtain");
        _sceneCurtain.RegisterCallback<GeometryChangedEvent>(FadeScreen);
    }

    private void Awake()
    {
        _instance = this;
    }

    private void FadeScreen(GeometryChangedEvent changeEvent)
    {
        _sceneCurtain.ToggleInClassList(_fadeTransitionName);
        _sceneCurtain.UnregisterCallback<GeometryChangedEvent>(FadeScreen);
    }

    public static void OpenScene(string sceneName)
    {
        _instance.StartCoroutine(_instance.openSceneRoutine(sceneName));
    }

    private IEnumerator openSceneRoutine(string sceneName)
    {
        _sceneCurtain.ToggleInClassList(_fadeTransitionName);
        yield return new WaitForSeconds(0.5f);
        SaveManager.SaveMonster(MonsterKey.Ghost);
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
    }
}

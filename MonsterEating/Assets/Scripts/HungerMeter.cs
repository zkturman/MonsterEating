using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HungerMeter : MonoBehaviour
{
    [SerializeField]
    private MonsterController _monsterController;
    private VisualElement _rootDocument;
    private VisualElement _progressMeter;

    private void OnEnable()
    {
        _monsterController = FindObjectOfType<MonsterController>();
        _rootDocument = GetComponent<UIDocument>().rootVisualElement;
        _progressMeter = _rootDocument.Q<VisualElement>("ProgressBar");
        _progressMeter.transform.scale = new Vector2(0, 1);
    }

    private void Update()
    {
        float currentPercent = _monsterController.GetEvolutionPercentage();
        if (currentPercent >= 0f)
        {
            _progressMeter.transform.scale = new Vector2(currentPercent, 1);
        }
    }
}

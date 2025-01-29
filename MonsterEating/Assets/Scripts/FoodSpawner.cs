using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _possibleFoodPrefabs;
    [SerializeField]
    private GameObject[] _possibleSpawnPoints;

    [SerializeField]
    private float _minTimeInSecondsBetweenSpawns = 1f;
    [SerializeField]
    private float _maxTimeInSecondsBetweenSpawns = 3f;
    private float _timeInSecondsBetweenSpawns;
    private float _elapsedTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        _timeInSecondsBetweenSpawns = Random.Range(_minTimeInSecondsBetweenSpawns, _maxTimeInSecondsBetweenSpawns);
    }

    // Update is called once per frame
    void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime > _timeInSecondsBetweenSpawns)
        {
            int foodDiceRoll = Random.Range(0, _possibleFoodPrefabs.Length);
            int spawnDiceRoll = Random.Range(0, _possibleSpawnPoints.Length);
            Instantiate(_possibleFoodPrefabs[foodDiceRoll], _possibleSpawnPoints[spawnDiceRoll].transform.position, Quaternion.identity);
            _elapsedTime = 0f;
        }
    }
}

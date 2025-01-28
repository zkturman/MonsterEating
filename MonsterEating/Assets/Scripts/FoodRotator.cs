using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodRotator : MonoBehaviour
{
    private Vector3 _rotationAxis;
    private float _rotationSpeed;
    [SerializeField]
    private Transform _foodTransform;
    // Start is called before the first frame update
    void Start()
    {
        _rotationAxis = Random.rotation.eulerAngles;
        _rotationSpeed = Random.Range(250, 450);
    }

    // Update is called once per frame
    void Update()
    {
        _foodTransform.RotateAround(transform.position, _rotationAxis, _rotationSpeed * Time.deltaTime);
    }
}

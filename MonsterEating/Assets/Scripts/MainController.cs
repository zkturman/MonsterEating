using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public class MainController : MonoBehaviour
{
    private short _moveValue = 0;
    private Rigidbody _playerBody;
    [SerializeField]
    private MonsterController _monsterMaster;
    // Start is called before the first frame update
    void Start()
    {
        _playerBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(new Vector3(0, -90 *  _moveValue, 0));
        _playerBody.velocity = new Vector3(_moveValue * 1, 0, 0) * _monsterMaster.GetCurrentMonsterSpeed();
        _monsterMaster.SetAnimation(_moveValue);
    }

    public void SetControllerMovement(short valueToSet)
    {
        _moveValue = valueToSet;
    }
}

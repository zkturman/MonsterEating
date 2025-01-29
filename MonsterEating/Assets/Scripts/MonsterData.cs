using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterData : MonoBehaviour
{
    [SerializeField]
    private int _speed = 5;
    public int Speed { get => _speed; }
    [SerializeField]
    private string _idleAnimationKey = "Idle";
    public string IdleAnimationKey { get => _idleAnimationKey; }
    [SerializeField]
    private string _moveAnimationKey = "Move";
    public string MoveAnimationKey { get => _moveAnimationKey; }
    [SerializeField]
    private string _eatAnimationKey = "Eat";
    public string EatAnimationKey { get => _eatAnimationKey; }
    [SerializeField]
    private Animator _monsterAnimator;
    public Animator MonsterAnimator { get => _monsterAnimator; }
    [SerializeField]
    private MonsterConsumer _monsterConsumer;
    public MonsterConsumer MonsterConsumer { get => _monsterConsumer; }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBase : UnitBase, IEnemy
{
    protected int _attackValue;

    protected int _movespeed;

    protected Transform _target;

    public int AttackValue => _attackValue;

    public int Movespeed => _movespeed;

    public Transform Target => _target;

    public void Init(int health, int attackValue, int movespeed)
    {
        Init(health);
        _attackValue = attackValue;
        _movespeed = movespeed;
        _target = GameObject.FindGameObjectWithTag("Player").transform;
    }
}

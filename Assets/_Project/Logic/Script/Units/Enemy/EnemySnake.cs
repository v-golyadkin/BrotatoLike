using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemySnake : EnemyBase
{
    private Animator _animator;

    private Vector3 _movementDirection;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _movementDirection = Target.position - transform.position;
        _movementDirection.Normalize();


        var playerToTheRight = Target.position.x > transform.position.x;
        transform.localScale = new Vector2(playerToTheRight ? -1 : 1, 1);
    }

    private void FixedUpdate()
    {
        transform.position += _movementDirection * _movespeed * Time.deltaTime;
    }

    public override void TakeDamage(int damage)
    {
        _animator.SetTrigger("hit");
        base.TakeDamage(damage);
    }
}

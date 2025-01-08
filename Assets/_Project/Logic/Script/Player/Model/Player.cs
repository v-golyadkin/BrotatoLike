using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Player : PlayerBase
{

    private float _movespeed;
    private int _maxHealth;

    public event Action<int> OnHealthChanged;

    public int MaxHealth => _maxHealth;

    private Rigidbody2D _body;
    private Animator _animator;

    private bool _isDead = false;

    private Vector2 _movementDirection;
    private int _facingDirection = 1;
    private float _moveHorizontal, _moveVertical;
    
    
    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            TakeDamage(1);
        }

        if(_isDead)
        {
            _movementDirection = Vector2.zero;
            _animator.SetFloat("velocity", 0);
            return;
        }

        _moveHorizontal = Input.GetAxisRaw("Horizontal");
        _moveVertical = Input.GetAxisRaw("Vertical");

        _movementDirection = new Vector2(_moveHorizontal, _moveVertical).normalized;

        _animator.SetFloat("velocity", _movementDirection.magnitude);

        if (_movementDirection.x != 0)
            _facingDirection = _movementDirection.x > 0 ? 1 : -1;

        transform.localScale = new Vector2(_facingDirection, 1);
    }

    private void FixedUpdate()
    {
        _body.velocity = _movementDirection * _movespeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IEnemy enemy = collision.gameObject.GetComponent<IEnemy>();

        if (enemy != null)
            TakeDamage(collision.gameObject.GetComponent<EnemyBase>().AttackValue);
    }

    public void Init(int health, int movespeed)
    {
        Init(health);
        _movespeed = movespeed;

        _maxHealth = health;
    }


    public override void TakeDamage(int damage)
    {
        _animator.SetTrigger("hit");
        base.TakeDamage(damage);

        OnHealthChanged?.Invoke(Health);
    }

    public override void Die()
    {
        _isDead = true;
        Destroy(gameObject);
        GameState.Instance.GameOver();
    }
}   

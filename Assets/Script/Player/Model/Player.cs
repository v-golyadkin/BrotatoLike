using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private TextMeshProUGUI healthText;

    [SerializeField] private float moveSpeed = 6f;
    [SerializeField] private int maxHealth = 10;

    public event Action<int> OnHealthChanged;

    //public int CurrentHealth => _currentHealth;
    public int MaxHealth => maxHealth;

    private Rigidbody2D _body;
    private Animator _animator;

    private bool _isDead = false;
    private int _currentHealth;

    private Vector2 _movement;
    private int _facingDirection = 1;
    private float _moveHorizontal, _moveVertical;
    
    
    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        FullHeal();
        //_currentHealth = maxHealth;
        //healthText.text = maxHealth.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Hit(1);
        }

        if(Input.GetKeyDown(KeyCode.H))
        {
            Heal(1);
        }

        if(_isDead)
        {
            _movement = Vector2.zero;
            _animator.SetFloat("velocity", 0);
            return;
        }

        _moveHorizontal = Input.GetAxisRaw("Horizontal");
        _moveVertical = Input.GetAxisRaw("Vertical");

        _movement = new Vector2(_moveHorizontal, _moveVertical).normalized;

        _animator.SetFloat("velocity", _movement.magnitude);

        if (_movement.x != 0)
            _facingDirection = _movement.x > 0 ? 1 : -1;

        transform.localScale = new Vector2(_facingDirection, 1);
    }

    private void FixedUpdate()
    {
        _body.velocity = _movement * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        if (enemy != null)
            Hit(1);
    }

    private void FullHeal()
    {
        Heal(maxHealth);
    }

    private void Heal(int amount)
    {
        _currentHealth += amount;

        if(_currentHealth > maxHealth)
        {
            _currentHealth = maxHealth;
        }

        OnHealthChanged?.Invoke(_currentHealth);
    }

    public void Hit(int damage)
    {
        _animator.SetTrigger("hit");
        _currentHealth -= damage;
        //healthText.text = Mathf.Clamp(_currentHealth, 0, maxHealth).ToString();
        OnHealthChanged?.Invoke(_currentHealth);

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        _isDead = true;

        GameState.Instance.GameOver();
    }
}   

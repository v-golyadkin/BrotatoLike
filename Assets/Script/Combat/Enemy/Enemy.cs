using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] private int maxHealth = 2;
    [SerializeField] private float moveSpeed = 2f;

    private Animator _animator;
    private Transform _target;

    private int _currentHealth;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        _currentHealth = maxHealth;
        _target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if(_target != null)
        {
            Vector3 direction = _target.position - transform.position;
            direction.Normalize();

            transform.position += direction * moveSpeed * Time.deltaTime;

            var playerToTheRight = _target.position.x > transform.position.x;
            transform.localScale = new Vector2(playerToTheRight ? -1 : 1, 1);
        }
    }

    public void Hit(int damage)
    {
        _currentHealth -= damage;
        _animator.SetTrigger("hit");

        if(_currentHealth <= 0)
        {
            Die();
        }
            
    }

    public void Die()
    {
        CoinWallet.Instance.AddCoins(1);

        Destroy(gameObject);     
    }
}

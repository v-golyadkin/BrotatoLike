using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBase : MonoBehaviour, IDamageable
{
    protected int _health;
    
    public int Health => _health;

    protected void Init(int health)
    {
        _health = health;        
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }

    public virtual void TakeDamage(int damage)
    {
        _health -= damage;
      
        if (_health <= 0)
        {
            Die();
        }
    }
}

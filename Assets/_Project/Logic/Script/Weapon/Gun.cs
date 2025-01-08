using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Animator))]
public class Gun : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject muzzle;
    [SerializeField] private Transform muzzlePosition;
    [SerializeField] private GameObject projectile;
    [SerializeField] private AudioSource shootSound;

    private float _timeSinceLastShot = 0f;

    private Transform _player;
    private Vector2 _offset;

    private Transform _closestEnemy;
    private Animator _animator;

    private ScriptableGun _gunConfig;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        transform.position = (Vector2)_player.position + _offset;

        FindClosestEnemy();
        AimAtEnemy();
        Shooting();
    }

    public void Init(Transform player, ScriptableGun gunConfig)
    {
        _player = player;
        _gunConfig = gunConfig;
        
        _timeSinceLastShot = _gunConfig.fireRate;
    }

    public void SetOffset(Vector2 offset)
    {
        _offset = offset;
    }

    private void FindClosestEnemy()
    {
        _closestEnemy = null;
        
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < _gunConfig.fireDistance) 
            {
                _closestEnemy = enemy.transform;
            }
        }
    }

    private void AimAtEnemy()
    {
        if( _closestEnemy != null)
        {
            Vector3 direction = _closestEnemy.position - transform.position;
            direction.Normalize();

            float angle = Mathf.Atan2(direction.y,direction.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, 0, angle);

            transform.position = (Vector2)_player.position + _offset;
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void Shooting()
    {
        if (_closestEnemy == null)
            return;

        _timeSinceLastShot += Time.deltaTime;

        if(_timeSinceLastShot >= _gunConfig.fireRate)
        {
            Shoot();
            _timeSinceLastShot = 0;
        }
    }

    private void Shoot()
    {
        _animator.SetTrigger("shoot");

        Instantiate(shootSound, transform.position, Quaternion.identity);

        var muzzleGO = Instantiate(muzzle, muzzlePosition.position, transform.rotation);
        muzzleGO.transform.SetParent(transform);
        Destroy(muzzleGO, 0.025f);

        var projectileGO = Instantiate(projectile, muzzlePosition.position, transform.rotation);
        projectileGO.GetComponent<Projectile>().Init(_gunConfig.damagePerShoot);
        
        Destroy(projectileGO, 3f);
    }
}

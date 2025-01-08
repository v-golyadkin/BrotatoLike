using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float timeBetweenSpawns = 1.5f;
    private float _currentTimeBetweenSpawns;

    Transform enemiesParent;

    private EnemyFactory _enemyFactory;
    
    private List<ScriptableEnemy> _enemyList = new List<ScriptableEnemy>();

    public static EnemySpawner Instance;

 

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }           
        else
        {
            Destroy(gameObject);
        }
   
        _enemyFactory = new EnemyFactory();
    }

    private void Start()
    {
        enemiesParent = GameObject.Find("Enemies").transform;
    }

    private void Update()
    {
        if (!WaveSpawner.Instance.WaveRunning()) { return; }

        _currentTimeBetweenSpawns -= Time.deltaTime;

        if(_currentTimeBetweenSpawns <= 0)
        {
            Spawn();
            _currentTimeBetweenSpawns = timeBetweenSpawns;
        }
    }

    private ScriptableEnemy RandomEnemy()
    {
        return _enemyList[Random.Range(0, _enemyList.Count)];
    }

    private Vector2 RandomPosition()
    {
        return new Vector2(Random.Range(-16, 16), Random.Range(-8, 8));
    }
    private void Spawn()
    {
        _enemyFactory.Create(RandomPosition(), enemiesParent);
    }

    public void DestroyAllEnemies()
    {
        foreach(Transform enemie in enemiesParent)
            Destroy(enemie.gameObject);
    }
}

using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float timeBetweenSpawns = 0.5f;
    private float _currentTimeBetweenSpawns;

    Transform enemiesParent;

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

    private Vector2 RandomPosition()
    {
        return new Vector2(Random.Range(-16, 16), Random.Range(-8, 8));
    }
    private void Spawn()
    {
        var enemy = Instantiate(enemyPrefab, RandomPosition(), Quaternion.identity);
        enemy.transform.SetParent(enemiesParent);
    }

    public void DestroyAllEnemies()
    {
        foreach(Transform enemie in enemiesParent)
            Destroy(enemie.gameObject);
    }
}

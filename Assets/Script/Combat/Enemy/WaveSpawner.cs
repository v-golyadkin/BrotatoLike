using System.Collections;
using TMPro;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshProUGUI waveText;

    public static WaveSpawner Instance;

    private bool _waveRunning = true;
    private int _currentWave = 0;
    private int _currentWaveTime;

    private void Awake()
    {
        if(Instance == null)
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
        StartNewWave();

        timeText.text = "30";
        waveText.text = "Wave: 1";
    }

    public bool WaveRunning()
    {
        return _waveRunning;
    }

    private void StartNewWave()
    {
        StopAllCoroutines();

        timeText.color = Color.white;

        _currentWave++;
        _waveRunning = true;
        _currentWaveTime = 30;

        waveText.text = $"Wave: {_currentWave}";
        StartCoroutine(WaveTimer());
    }

    private IEnumerator WaveTimer()
    {
        while (_waveRunning)
        {
            yield return new WaitForSeconds(1f);
            _currentWaveTime--;

            timeText.text = _currentWaveTime.ToString();

            if(_currentWaveTime <= 0)
            {
                WaveComplete();
            }
        }
        yield return null;
    }

    private void WaveComplete()
    {
        StopAllCoroutines();
        _waveRunning = false;
        EnemySpawner.Instance.DestroyAllEnemies();
        _currentWaveTime = 30;
        timeText.text = _currentWaveTime.ToString();
        timeText.color = Color.red;

        Invoke("StartNewWave", 5f);
        
    }
}

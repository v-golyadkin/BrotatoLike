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
    private int _baseWaveTime = 30;

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
        timeText.text = $"{_baseWaveTime + 5 * _currentWave}";
        waveText.text = "Wave: 1";

        StartNewWave();      
    }

    public bool WaveRunning()
    {
        return _waveRunning;
    }

    private void StartNewWave()
    {
        StopAllCoroutines();

        timeText.color = Color.white;

        if(_currentWave / 2 == 1 && _currentWave != 1)
        {
            GunSpawner.Instance.TryAddGun();
        }

        if(_currentWave == 12)
        {
            GameState.Instance.WinGame();
            return;
        }

        _currentWaveTime = _baseWaveTime + 5 * _currentWave;
        _currentWave++;
        _waveRunning = true;
        

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
        WaveEnd();

        _currentWaveTime = _baseWaveTime + 5 * _currentWave;
        timeText.text = _currentWaveTime.ToString();

        Invoke("StartNewWave", 5f);       
    }

    public void WaveEnd()
    {
        StopAllCoroutines();
        _waveRunning = false;
        EnemySpawner.Instance.DestroyAllEnemies();
        timeText.color = Color.red;
    }
}

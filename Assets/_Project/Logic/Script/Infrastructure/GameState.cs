using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameState : MonoBehaviour
{
    [SerializeField] private GameObject gameFinishPanel;
    [SerializeField] private Button restartButton;

    public static GameState Instance;

    private bool _gameRunning;

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
        restartButton.onClick.AddListener(RestartGame);
    }


    public bool IsGameRunning()
    {
        return _gameRunning;
    } 

    public void GameOver()
    {                               
        _gameRunning = false;                                                                                                                                                                                                                                                                                                                                                                                                                                                                       
        gameFinishPanel.SetActive(true);
        gameFinishPanel.GetComponentInChildren<TextMeshProUGUI>().text = "YOU LOST";
        WaveSpawner.Instance.WaveEnd();
        GunSpawner.Instance.DestroyAllGun();
    }

    public void WinGame()
    {
        _gameRunning = false;
        gameFinishPanel.SetActive(true);
        gameFinishPanel.GetComponentInChildren<TextMeshProUGUI>().text = "YOU WIN";
        WaveSpawner.Instance.WaveEnd();
        GunSpawner.Instance.DestroyAllGun();

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}

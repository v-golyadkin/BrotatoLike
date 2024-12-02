using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private Button restartButton;

    public static GameManager Instance;

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
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}

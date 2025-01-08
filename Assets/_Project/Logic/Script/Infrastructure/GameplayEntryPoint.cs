using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplayEntryPoint : MonoBehaviour
{
    [SerializeField] private Slider mainHealthBar;
    [SerializeField] private TextMeshProUGUI mainHealthBarText;
    [SerializeField] private Slider followHealthBar;

    private GameObject _player;

    private void Start()
    {
        InitPlayer();

        InitUI();
    }

    private void InitPlayer()
    {
        PlayerFactory playerFactory = new PlayerFactory();
        _player = playerFactory.Create().gameObject;

        Camera.main.GetComponent<CameraFollow>().Init(_player.transform);
        GunSpawner.Instance.Init(_player.transform);
    }

    private void InitUI()
    {
        _player.GetComponent<PlayerView>().Init(mainHealthBar, mainHealthBarText, followHealthBar);
    }
}

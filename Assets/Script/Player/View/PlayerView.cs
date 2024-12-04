using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private Slider mainHealthBar;
    [SerializeField] private TextMeshProUGUI mainHealthBarText;
    [SerializeField] private Slider healthBar;

    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void Start()
    {
        InitHealthUI();
    }

    private void OnEnable()
    {
        _player.OnHealthChanged += UpdateHealthUI;
    }


    private void OnDisable()
    {
        _player.OnHealthChanged -= UpdateHealthUI;
    }

    private void InitHealthUI()
    {
        mainHealthBar.maxValue = _player.MaxHealth;
        healthBar.maxValue = _player.MaxHealth;
    }

    private void UpdateHealthUI(int currentHealth)
    {
        mainHealthBar.value = currentHealth;
        mainHealthBarText.text = $"{currentHealth}/{_player.MaxHealth}";

        healthBar.gameObject.SetActive(currentHealth != _player.MaxHealth);
        healthBar.value = currentHealth;
    }


}

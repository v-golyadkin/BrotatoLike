using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private Slider _mainHealthBar;
    [SerializeField] private TextMeshProUGUI _mainHealthBarText;
    [SerializeField] private Slider _followHealthBar;

    private Player _player;
    private int _maxHealth;


    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        _player.OnHealthChanged += UpdateHealthUI;
    }


    private void OnDisable()
    {
        _player.OnHealthChanged -= UpdateHealthUI;
    }

    public void Init(Slider mainHealthBar, TextMeshProUGUI mainHealthBarText, Slider followHeathBar)
    {
        _mainHealthBar = mainHealthBar;
        _mainHealthBarText = mainHealthBarText;
        _followHealthBar = followHeathBar;

        _followHealthBar.gameObject.GetComponentInParent<Follow>().SetTarget(_player.transform);

        InitHealthUI(_player.Health);
    }

    private void InitHealthUI(int maxHealth)
    {
        _maxHealth = maxHealth;

        _mainHealthBar.maxValue = _maxHealth;
        _followHealthBar.maxValue = _maxHealth;

        UpdateHealthUI(_maxHealth);
    }

    private void UpdateHealthUI(int currentHealth)
    {
        _mainHealthBar.value = currentHealth;
        _mainHealthBarText.text = $"{currentHealth}/{_maxHealth}";

        _followHealthBar.gameObject.SetActive(currentHealth != _maxHealth);
        _followHealthBar.value = currentHealth;
    }


}

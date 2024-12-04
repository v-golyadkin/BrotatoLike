using TMPro;
using UnityEngine;

public class CoinWalletView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinCounterText;

    private CoinWallet _coinWallet;

    private void Awake()
    {
        _coinWallet = GetComponent<CoinWallet>();
    }

    private void Start()
    {
        coinCounterText.text = $"{_coinWallet.Coins}$";
    }

    private void OnEnable()
    {
        _coinWallet.OnCoinsChanged += UpdateCoinCounterText;
    }

    private void OnDisable()
    {
        _coinWallet.OnCoinsChanged -= UpdateCoinCounterText;
    }

    private void UpdateCoinCounterText(int currentCoins)
    {
        coinCounterText.text = $"{currentCoins}$";
    }
}

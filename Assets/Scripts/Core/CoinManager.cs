using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance { get; private set; }

    [SerializeField] 
    private TextMeshProUGUI coinText;
    
    private int coin;

    private void Awake()
    {
        Instance = this;
        coin = 0;
        SetCoinText();
    }

    public void AddCoin()
    {
        coin++;
        SetCoinText();
    }

    public int GetCoinAmount()
    {
        return coin;
    }

    private void SetCoinText()
    {
        coinText.text = coin.ToString();
    }
}

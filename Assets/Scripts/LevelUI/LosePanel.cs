using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LosePanel : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    [SerializeField] private Button menuButton;

    private int coin;

    private void OnEnable()
    {
        coin = CoinManager.Instance.GetCoinAmount();
    }

    private void Start()
    {
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (restartButton != null)
        {
            restartButton.onClick.RemoveAllListeners();
            restartButton.onClick.AddListener(() =>
            {
                CoinData.Instance.PlusCoin(coin);
                SceneManager.LoadScene(1);
            });
        }

        if (menuButton != null)
        {
            menuButton.onClick.RemoveAllListeners();
            menuButton.onClick.AddListener(() =>
            {
                CoinData.Instance.PlusCoin(coin);
                SceneManager.LoadScene(1);
            });
        }
    }
}

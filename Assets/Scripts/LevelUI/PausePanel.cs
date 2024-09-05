using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    [SerializeField] 
    private Button continueButton;
    [SerializeField] 
    private Button restartButton;
    [SerializeField]
    private Button menuButton;

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
        if (continueButton != null)
        {
            continueButton.onClick.RemoveAllListeners();
            continueButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                Time.timeScale = 1f;
            });
        }

        if (restartButton != null)
        {
            restartButton.onClick.RemoveAllListeners();
            restartButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(2);
                CoinData.Instance.PlusCoin(coin);
            });
        }

        if (menuButton != null)
        {
            menuButton.onClick.RemoveAllListeners();
            menuButton.onClick.AddListener(() =>
            {
                SceneManager.LoadScene(1);
                Time.timeScale = 1f;
                CoinData.Instance.PlusCoin(coin);
            });
        }
    }
}

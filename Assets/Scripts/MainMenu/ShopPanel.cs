using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopPanel : MonoBehaviour
{
    [SerializeField] 
    private Button backButton;

    [Space(13)]
    
    [SerializeField] 
    private Button[] buyButton;
    [SerializeField] 
    private GameObject[] priceGameObject;

    private int[] gunPrice = new int[] {250, 500, 750, 1000};

    [Space(13)] 
    
    [SerializeField]
    private TextMeshProUGUI coinText;
    
    [Space(13)]
    
    [SerializeField]
    private GameObject mainPanel;

    private void OnEnable()
    {
        ActiveBuyObjects();
        SetCoinText();
    }

    private void Start()
    {
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (backButton != null)
        {
            backButton.onClick.RemoveAllListeners();
            backButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                mainPanel.SetActive(true);
            });
        }

        if (buyButton[0] != null)
        {
            buyButton[0].onClick.RemoveAllListeners();
            buyButton[0].onClick.AddListener(() =>
            {
                BuyGun(0);
                ActiveBuyObjects();
                SetCoinText();
            });
        }
        
        if (buyButton[1] != null)
        {
            buyButton[1].onClick.RemoveAllListeners();
            buyButton[1].onClick.AddListener(() =>
            {
                BuyGun(1);
                ActiveBuyObjects();
                SetCoinText();
            });
        }
        
        if (buyButton[2] != null)
        {
            buyButton[2].onClick.RemoveAllListeners();
            buyButton[2].onClick.AddListener(() =>
            {
                BuyGun(2);
                ActiveBuyObjects();
                SetCoinText();
            });
        }
        
        if (buyButton[3] != null)
        {
            buyButton[3].onClick.RemoveAllListeners();
            buyButton[3].onClick.AddListener(() =>
            {
                BuyGun(3);
                ActiveBuyObjects();
                SetCoinText();
            });
        }
    }

    private void ActiveBuyObjects()
    {
        for (int i = 0; i < buyButton.Length; i++)
        {
            if (ShopData.Instance.GetBuyGun(i))
            {
                buyButton[i].gameObject.SetActive(false);
                priceGameObject[i].gameObject.SetActive(false);
            }
            else
            {
                buyButton[i].gameObject.SetActive(true);
                priceGameObject[i].gameObject.SetActive(true);
            }
        }
    }

    private void SetCoinText()
    {
        coinText.text = CoinData.Instance.GetCoinAmount().ToString();
    }

    private void BuyGun(int index)
    {
        if (CoinData.Instance.GetCoinAmount() > gunPrice[index])
        {
            CoinData.Instance.MinusCoin(gunPrice[index]);
            ShopData.Instance.OpenGun(index);
        }
    }
}

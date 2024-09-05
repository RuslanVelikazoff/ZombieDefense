using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour
{
    [SerializeField]
    private Button startButton;
    [SerializeField]
    private Button settingsButton;
    [SerializeField] 
    private Button shopButton;

    [Space(13)]

    [SerializeField]
    private GameObject settingsPanel;
    [SerializeField]
    private GameObject shopPanel;

    private void Start()
    {
        ButtonClickAction();
    }

    private void ButtonClickAction()
    {
        if (startButton != null)
        {
            startButton.onClick.RemoveAllListeners();
            startButton.onClick.AddListener(() =>
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene(2);
            });
        }

        if (settingsButton != null)
        {
            settingsButton.onClick.RemoveAllListeners();
            settingsButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                settingsPanel.SetActive(true);
            });
        }

        if (shopButton != null)
        {
            shopButton.onClick.RemoveAllListeners();
            shopButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                shopPanel.SetActive(true);
            });
        }
    }
}

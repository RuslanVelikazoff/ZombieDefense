using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField]
    private Button backButton;
    [SerializeField]
    private Button musicButton;
    [SerializeField]
    private Button soundButton;

    [Space(13)]
    
    [SerializeField]
    private GameObject mainPanel;

    [Space(13)]
    
    [SerializeField]
    private Sprite offSprite;
    [SerializeField]
    private Sprite onSprite;

    private void OnEnable()
    {
        SetMusicButtonSprite();
        SetSoundButtonSprite();
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

        if (musicButton != null)
        {
            musicButton.onClick.RemoveAllListeners();
            musicButton.onClick.AddListener(() =>
            {
                if (AudioManager.Instance.MusicPlay())
                {
                    AudioManager.Instance.OffMusic();
                }
                else
                {
                    AudioManager.Instance.OnMusic();
                }
                
                SetMusicButtonSprite();
            });
        }

        if (soundButton != null)
        {
            soundButton.onClick.RemoveAllListeners();
            soundButton.onClick.AddListener(() =>
            {
                if (AudioManager.Instance.SoundPlay())
                {
                    AudioManager.Instance.OffSounds();
                }
                else
                {
                    AudioManager.Instance.OnSounds();
                }
                
                SetSoundButtonSprite();
            });
        }
    }

    private void SetMusicButtonSprite()
    {
        if (AudioManager.Instance.MusicPlay())
        {
            musicButton.GetComponent<Image>().sprite = onSprite;
        }
        else
        {
            musicButton.GetComponent<Image>().sprite = offSprite;
        }
    }

    private void SetSoundButtonSprite()
    {
        if (AudioManager.Instance.SoundPlay())
        {
            soundButton.GetComponent<Image>().sprite = onSprite;
        }
        else
        {
            soundButton.GetComponent<Image>().sprite = offSprite;
        }
    }
}

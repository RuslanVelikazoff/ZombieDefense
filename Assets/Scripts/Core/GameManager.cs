using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] 
    private GameObject pausePanel;

    [SerializeField] 
    private GameObject losePanel;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Time.timeScale = 1f;
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void LoseGame()
    {
        AudioManager.Instance.Play("Lose");
        Time.timeScale = 0f;
        losePanel.SetActive(true);
    }
}

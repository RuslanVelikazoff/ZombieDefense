using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartLoading : MonoBehaviour
{
    private bool loadStart = false;

    private float timeLeft;
    private float loadTime = 2f;

    [SerializeField]
    private Slider sliderLoader;

    private void Update()
    {
        if (loadStart)
        {
            timeLeft += Time.deltaTime;
            sliderLoader.value = timeLeft;

            if (timeLeft >= loadTime)
            {
                StartGame();
            }
        }
    }

    public void LoadStart()
    {
        loadStart = true;
    }

    private void StartGame()
    {
        Screen.orientation = ScreenOrientation.LandscapeRight;
        SceneManager.LoadScene(1);
    }
}

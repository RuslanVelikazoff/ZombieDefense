using System.Collections;
using UnityEngine;

public class Policy : MonoBehaviour
{
     public StartLoading loader;
    public UniWebView policyWebView;
    public string policyUrl;
    public GameObject noConnectionScreen;
    public GameObject loadingScreen;
    public GameObject webViewScreen;
    public GameObject policyBackground, otherBackground;

    private bool isPageLoadCompleteHandled = false;

    private void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
        VerifyInitialConnection();
    }

    private void VerifyInitialConnection()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            loadingScreen.SetActive(false);
            noConnectionScreen.SetActive(true);
        }
        else
        {
            ProceedBasedOnPolicyStatus();
        }
    }

    private IEnumerator MonitorConnectionAndProceed()
    {
        while (Application.internetReachability == NetworkReachability.NotReachable)
        {
            loadingScreen.SetActive(false);
            noConnectionScreen.SetActive(true);
            yield return new WaitForSeconds(5f);
        }

        noConnectionScreen.SetActive(false);
        loadingScreen.SetActive(true);
        ShowPolicyPage();
    }

    private void ShowPolicyPage()
    {
        policyWebView.OnPageFinished += OnPolicyPageLoadComplete;
        policyWebView.Load(policyUrl);
    }

    private void OnPolicyPageLoadComplete(UniWebView webView, int statusCode, string currentUrl)
    {
        if (isPageLoadCompleteHandled) return;

        UpdateUI(currentUrl);
        policyWebView.Show();

        if (policyUrl != currentUrl)
        {
            PlayerPrefs.SetString("PolicyStatus", currentUrl);
            Destroy(gameObject);
        }

        isPageLoadCompleteHandled = true;
    }

    private void UpdateUI(string currentUrl)
    {
        bool isPolicyPage = currentUrl == policyUrl;
        GameObject activeBackground = isPolicyPage ? policyBackground : otherBackground;
        activeBackground.SetActive(true);
        Screen.orientation = isPolicyPage ? ScreenOrientation.Portrait : ScreenOrientation.AutoRotation;
        PlayerPrefs.SetString("PolicyStatus", isPolicyPage ? "Confirmed" : currentUrl);
    }

    public void AcceptPolicy()
    {
        ProceedBasedOnPolicyStatus();
    }

    public void Back()
    {
        if (policyWebView.CanGoBack)
        {
            policyWebView.GoBack();
        }
    }

    public void Forward()
    {
        if (policyWebView.CanGoForward)
        {
            policyWebView.GoForward();
        }
    }

    private void ProceedBasedOnPolicyStatus()
    {
        if (PlayerPrefs.GetString("PolicyStatus", "") == "")
        {
            StartCoroutine(MonitorConnectionAndProceed());
        }
        else
        {
            string policyStatus = PlayerPrefs.GetString("PolicyStatus", "");
            if (policyStatus == "Confirmed")
            {
                LaunchGame();
            }
            else
            {
                DisplayURL(policyStatus);
            }
        }
    }

    private void LaunchGame()
    {
        webViewScreen.SetActive(false);
        policyWebView.gameObject.SetActive(false);
        policyBackground.SetActive(false);
        loadingScreen.SetActive(true);
        loader.LoadStart();
    }

    private void DisplayURL(string policyStatus)
    {
        webViewScreen.SetActive(true);
        policyWebView.gameObject.SetActive(true);
        policyWebView.Load(policyStatus);
        policyWebView.Show();
        otherBackground.SetActive(true);
    }
}

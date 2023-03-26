using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class GameOverButton : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [Header("Ads")]
    [SerializeField] private Button _showAdButton;
    private string _adUnitId = "Rewarded_Android";

    [Header("Scene actions")]
    [SerializeField] private PlayerStats _playerStats;
    [SerializeField] private PlayerMovement _playerMovement;
    [SerializeField] private GameObject _gameOverUIMenu;
    [SerializeField] private GameObject _gameplayUIMenu;
    [SerializeField] private SceneSwitcher _sceneSwitcher;

    private Timer _timer;

    void Awake()
    {
        _showAdButton.interactable = false;

        _timer = GetComponentInParent<Timer>();
        _playerStats.GameOvered += PreGameOver;
        _timer.TimerOff += GameOver;
    }

    private void Start()
    {
        LoadAd();
        _gameOverUIMenu.SetActive(false);
    }
    public void LoadAd()
    {
        Debug.Log("Loading Ad: " + _adUnitId);
        Advertisement.Load(_adUnitId, this);
    }

    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log("Ad Loaded: " + adUnitId);

        if (adUnitId.Equals(_adUnitId))
        {
            _showAdButton.onClick.AddListener(ShowAd);
            _showAdButton.interactable = true;
        }
    }

    public void ShowAd()
    {
        _showAdButton.interactable = false;
        Advertisement.Show(_adUnitId, this);
        Time.timeScale = 0;
    }

    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId.Equals(_adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("Unity Ads Rewarded Ad Completed");
            // Grant a reward.
            Time.timeScale = 1;
            _gameplayUIMenu.SetActive(true);
            _gameOverUIMenu.SetActive(false);
            _playerStats.Respawn();
            _playerMovement.OnDamageTaken();
            // Load another ad:
            Advertisement.Load(_adUnitId, this);
        }
    }

    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
    }

    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }

    void OnDestroy()
    {
        _showAdButton.onClick.RemoveAllListeners();
        _playerStats.GameOvered += PreGameOver;
        _timer.TimerOff -= GameOver;
    }

    private void PreGameOver()
    {
        _gameplayUIMenu.SetActive(false);
        _gameOverUIMenu.SetActive(true);
    }
    private void GameOver()
    {
        _sceneSwitcher.ToMainMenu();
    }
}

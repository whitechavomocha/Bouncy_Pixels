using Ball;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdManager : MonoBehaviour, IUnityAdsListener
{
    public static AdManager Instance;

    [SerializeField] private bool testMode = false;

#if UNITY_ANDROID
     private string gameId = "4457933";
#elif UNITY_IOS
    private string gameId = "4457932";
#endif
    
    private LevelManager levelManager;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            Advertisement.AddListener(this);
            Advertisement.Initialize(gameId, testMode);
        }
    }

    public void ShowAd(LevelManager levelManager)
    {
        this.levelManager = levelManager;
        Advertisement.Show("rewardedVideo");
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.LogError($"Unity Ads Error: {message}");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch (showResult)
        {
            case ShowResult.Finished:
                //Ad watched
                //Reward func here
                Car.Instance.Continue();
                Debug.Log("Reward claimed!");
                break;
            case ShowResult.Skipped:
                //Ad skipped
                break;
            case ShowResult.Failed:
                Debug.LogWarning("Ad Failed!");
                break;
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("Ad Started!");
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("Unity Ads Ready!");
    }

}

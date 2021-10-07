using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;

public class ControleAnuncio : MonoBehaviour,IUnityAdsLoadListener, IUnityAdsShowListener
{
    
    [SerializeField] Button btnAnuncio;
    [SerializeField] string androidAdUnitId = "Rewarded_Android";
    [SerializeField] string IOSAdUnitId = "Rewarded_iOS";
    
    string adUnitId;

    void Awake()
    {
        // Get the Ad Unit ID for the current platform:
        adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? IOSAdUnitId
            : androidAdUnitId;

        //Disable button until ad is ready to show
        btnAnuncio.interactable = false;
    }

    private void OnEnable()
    {
        LoadAd();
    }

    // Load content to the Ad Unit:
    public void LoadAd()
    {
        // IMPORTANT! Only load content AFTER initialization
        // (in this example, initialization is handled in a different script).
        Debug.Log("Loading Ad: " + adUnitId);
        Advertisement.Load(adUnitId, this);
    }

    // If the ad successfully loads, add a listener to the button and enable it:
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log("Ad Loaded: " + adUnitId);

        if (adUnitId.Equals(this.adUnitId))
        {
            // Configure the button to call the ShowAd() method when clicked:
            btnAnuncio.onClick.AddListener(this.ShowAd);
            // Enable the button for users to click:
            btnAnuncio.interactable = true;
        }
    }

    // Implement a method to execute when the user clicks the button.
    public void ShowAd()
    {
        // Disable the button: 
        btnAnuncio.interactable = false;
        // Then show the ad:
        Advertisement.Show(adUnitId, this);
    }

    // Implement the Show Listener's OnUnityAdsShowComplete callback method to determine if the user gets a reward:
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId.Equals(this.adUnitId) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("Recompensa");
            // Grant a reward.

            // Load another ad:
            Advertisement.Load(this.adUnitId, this);
        }
    }

    // Implement Load and Show Listener error callbacks:
    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.LogError($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
        // Use the error details to determine whether to try to load another ad.
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.LogError($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
        // Use the error details to determine whether to try to load another ad.
    }
    

    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { }

    void OnDestroy()
    {
        // Clean up the button listeners:
        btnAnuncio.onClick.RemoveAllListeners();
    }
}

using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAds : MonoBehaviour
{
    public static BannerAds Instance;

    [SerializeField] private string androidAdUnitId = "Banner_Android";
    [SerializeField] private string iosAdUnitId = "Banner_iOS";
    private string adUnitId;
    private bool isBannerLoaded = false;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        adUnitId = Application.platform == RuntimePlatform.IPhonePlayer ? iosAdUnitId : androidAdUnitId;
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        LoadBanner();
    }

    public void LoadBanner()
    {
        Advertisement.Banner.Load(adUnitId, new BannerLoadOptions
        {
            loadCallback = () =>
            {
                isBannerLoaded = true;
                ShowBannerAd(); // auto show when loaded
            },
            errorCallback = (msg) =>
            {
                Debug.LogWarning("Banner failed to load: " + msg);
                isBannerLoaded = false;
            }
        });
    }

    public void ShowBannerAd()
    {
        if (isBannerLoaded)
        {
            Advertisement.Banner.Show(adUnitId);
        }
        else
        {
            Debug.Log("Banner not yet loaded, attempting reload...");
            LoadBanner();
        }
    }

    public void HideBannerAd()
    {
        Advertisement.Banner.Hide();
    }
}
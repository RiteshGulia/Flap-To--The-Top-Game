using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
public class MainMenuScript : MonoBehaviour
{
    public AudioMixer mainMixer;
   private void Start()
    {
        if (BannerAds.Instance != null)
        {
            BannerAds.Instance.ShowBannerAd();
        }
    }

    public void SetVolume(float volume)
    {
      mainMixer.SetFloat("MainMenuVolume", volume);
    }  
    public void PlayGame()
    {
       BannerAds.Instance?.HideBannerAd();
      SceneManager.LoadSceneAsync(1);
    }
    public void QuitGame()
    {
      Application.Quit();
    }
    public void SetFullScreen (bool isFullScreen)
    {
      Screen.fullScreen = !Screen.fullScreen;
    }
    public void SetQuality(int qualityIndex)
    {
      QualitySettings.SetQualityLevel(qualityIndex);
    }
}

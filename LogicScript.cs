using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public AudioSource dingSFX;
    public Text highScoreText;
    public int highScore;
    public void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore",0);
    highScoreText.text = highScore.ToString(); 
     }
        [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore += scoreToAdd;
        scoreText.text = playerScore.ToString();
        dingSFX.Play();
        if (playerScore > highScore)
        {
            highScore = playerScore;
            highScoreText.text = highScore.ToString();
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
        }
    }
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
          int gamesPlayed = PlayerPrefs.GetInt("GamesPlayed", 0);
        gamesPlayed++;
        PlayerPrefs.SetInt("GamesPlayed", gamesPlayed);

        if (gamesPlayed % 3 == 0 && InterstitialAds.Instance != null)
        {
            InterstitialAds.Instance.ShowAd();
        }
    }

    public void ResetGame()
    {
        playerScore = 0;
        scoreText.text = "0";
        gameOverScreen.SetActive(false);
    }
    public void WatchAdToContinue()
    {
        if (RewardedAds.Instance != null)
        {
            RewardedAds.Instance.ShowAd(() =>
            {
                ResetGame(); // hide game over screen
                Object.FindFirstObjectByType<BirdScript>().InitializeBird(); 
            });
        }
    }
}
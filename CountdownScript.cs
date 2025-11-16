using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;
public class CountdownScript : MonoBehaviour
{ public TextMeshProUGUI countdownText;
public BirdScript birdScript;
public PipeSpawnScript pipeSpawnScript;
public float countdownTime = 3f;

    
    void Start()
    {
      birdScript.enabled = false;
      pipeSpawnScript.enabled = false;
        birdScript.myRigidbody.simulated = false;
        StartCoroutine(CountdownRoutine());
    }

    
      IEnumerator CountdownRoutine()
    {
        float timeLeft = countdownTime;

        while (timeLeft > 0)
        {
            countdownText.text = Mathf.Ceil(timeLeft).ToString();
            yield return new WaitForSeconds(1f);
            timeLeft--;
        }

        countdownText.text = "Go";
        yield return new WaitForSeconds(1f);
        countdownText.gameObject.SetActive(false);

        birdScript.InitializeBird();
        birdScript.enabled = true;
        pipeSpawnScript.enabled = true;
        birdScript.myRigidbody.simulated = true;
    }
}

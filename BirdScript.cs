using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public float upperLimit = 17f;
    public float lowerLimit = -28f;
    public AudioClip flapSound;
    public AudioClip deathSound;
    public AudioClip hitSound;
    private AudioSource audioSource;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>(); 
        audioSource = GetComponent<AudioSource>();
    }

    public void InitializeBird()
    {
        birdIsAlive = true;
        myRigidbody.linearVelocity = Vector2.zero;
        transform.position = new Vector2(-2.5f, 0);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
      { myRigidbody.linearVelocity = Vector2.up * flapStrength;
        PlayFlapSound();
      }
       if (transform.position.y > upperLimit || transform.position.y < lowerLimit)
        {
           Debug.Log("Game Over Condition Met");
            GameOver();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (birdIsAlive)              
        { 
            PlayHitSound();
            logic.gameOver();
            birdIsAlive = false;
        }
    }

    private void GameOver()
    {
        if (birdIsAlive) 
        {
            PlayDeathSound();
            logic.gameOver();
            birdIsAlive = false;
        }
    }
     
    private void PlayFlapSound()
    {
        if (flapSound != null)
        {
            audioSource.PlayOneShot(flapSound);
        }
    }

    private void PlayDeathSound()
    {
        if (deathSound != null)
        {
            audioSource.PlayOneShot(deathSound);
        }
    }

    private void PlayHitSound()
    {
        if (hitSound != null)
        {
            audioSource.PlayOneShot(hitSound);
        }
    }
}
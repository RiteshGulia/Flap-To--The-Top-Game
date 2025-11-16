using UnityEngine;

public class CloudScript : MonoBehaviour
{
    public GameObject cloudPrefab;
    public float spawnInterval = 3.0f;
    public Vector2 spawnRangeY = new Vector2(-1.0f, 4.0f);
    public float cloudSpeed = 2.0f;
    public int maxClouds = 7;

    private Transform[] clouds;

    void Start()
    {
        clouds = new Transform[maxClouds];
        InvokeRepeating("SpawnCloud", 0f, spawnInterval);
    }

    void Update()
    {
        MoveClouds();
    }

    void SpawnCloud()
    {
        for (int i = 0; i < maxClouds; i++)
        {
            if (clouds[i] == null)
            {
                   float randomYViewport = Random.Range(0.3f, 0.8f);
Vector3 spawnPos = Camera.main.ViewportToWorldPoint(new Vector3(1.1f, randomYViewport, Camera.main.nearClipPlane));
spawnPos.z = 0f;
clouds[i] = Instantiate(cloudPrefab, spawnPos, Quaternion.identity).transform;
                clouds[i].parent = transform;
                break;
            }
        }
    }

    void MoveClouds()
    {
        for (int i = 0; i < maxClouds; i++)
        {
            if (clouds[i] != null)
            {
                clouds[i].position += new Vector3(-cloudSpeed * Time.deltaTime, 0, 0);
                if (clouds[i].position.x < -20f)
                {
                    Destroy(clouds[i].gameObject);
                    clouds[i] = null;
                }
            }
        }
    }
}

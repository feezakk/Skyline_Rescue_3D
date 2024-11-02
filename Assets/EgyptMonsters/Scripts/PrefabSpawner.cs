using UnityEngine;

public class PrefabSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn; // The prefab to spawn
    public float spawnInterval = 15f; // Interval in seconds
    public Vector2 xRange = new Vector2(0f, 1000f); // Range for random x position
    public Vector2 zRange = new Vector2(0f, 1000f); // Range for random z position

    private float timer;
    
    public GameObject objectToTrack;
    
    public float distanceFromCamera = 10f; 
    
    void Start()
    {
        // Define the corners in screen space
        Vector3 bottomLeft = new Vector3(0, 0, distanceFromCamera);
        Vector3 bottomRight = new Vector3(Screen.width, 0, distanceFromCamera);
        Vector3 topLeft = new Vector3(0, Screen.height, distanceFromCamera);
        Vector3 topRight = new Vector3(Screen.width, Screen.height, distanceFromCamera);

        // Convert to world space
        Vector3 worldBottomLeft = Camera.main.ScreenToWorldPoint(bottomLeft);
        Vector3 worldBottomRight = Camera.main.ScreenToWorldPoint(bottomRight);
        Vector3 worldTopLeft = Camera.main.ScreenToWorldPoint(topLeft);
        Vector3 worldTopRight = Camera.main.ScreenToWorldPoint(topRight);

        // Output world positions to console
        Debug.Log("World Bottom Left: " + worldBottomLeft);
        Debug.Log("World Bottom Right: " + worldBottomRight);
        Debug.Log("World Top Left: " + worldTopLeft);
        Debug.Log("World Top Right: " + worldTopRight);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnPrefabAtRandomLocation();
            timer = 0f; // Reset timer
        }
        
        if (objectToTrack != null)
        {
            // Get the object's world position
            Vector3 worldPosition = objectToTrack.transform.position;

            // Convert the world position to screen position
            Vector3 screenPosition = Camera.main.WorldToScreenPoint(worldPosition);

            // Display screen coordinates in the console
            //Debug.Log("Screen Position: " + screenPosition);
        }
        
        GameObject player = GameObject.Find("PlaneS2");
        
        Debug.Log("Player: " + player);
        
        // Get the player's world position
        Vector3 playerPosition = player.transform.position;

        // Display the player's position in the console
        Debug.Log("Player Position: " + playerPosition);
    }

    void SpawnPrefabAtRandomLocation()
    {
        float randomX = Random.Range(0, 1000); // Random x position
        float randomZ = Random.Range(0, 1000); // Random z position

        // Log the values to check if they are within the expected range
        //Debug.Log("Random X: " + randomX + " | Random Z: " + randomZ);

        Vector3 spawnPosition = new Vector3(randomX, 0f, randomZ); // Set y to 0
        Quaternion spawnRotation = Quaternion.Euler(0, 180, 0); // Rotate 180 degrees on the Y-axis

        GameObject spawnedObject = Instantiate(prefabToSpawn, spawnPosition, spawnRotation);
        spawnedObject.SetActive(true);
        //Debug.Log("Prefab spawned and set active at: " + spawnPosition);
    }
}


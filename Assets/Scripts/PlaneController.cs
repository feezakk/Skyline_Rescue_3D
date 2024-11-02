using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float speed = 10f; // Speed of the plane

    void Update()
    {
        // Get input for movement
        float horizontalInput = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float verticalInput = Input.GetAxis("Vertical");     // W/S or Up/Down

        // Calculate movement direction
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput).normalized;

        // Move the plane forward in the direction
        transform.Translate(direction * speed * Time.deltaTime, Space.World);
    }
}


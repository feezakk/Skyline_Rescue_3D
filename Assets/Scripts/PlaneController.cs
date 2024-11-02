using UnityEngine;

public class PlaneController : MonoBehaviour
{
    public float speed = 50f;            // Speed of the plane
    public float rotationSpeed = 50f;    // Speed of rotation
    public float liftSpeed = 50f;         // Speed for moving up and down

    void Update()
    {
        // Get input for movement
        float horizontalInput = Input.GetAxis("Horizontal");   // A/D or Left/Right for movement
        float verticalInput = Input.GetAxis("Vertical");       // W/S or Up/Down for forward/backward movement
        float liftInput = (Input.GetKey(KeyCode.Space) ? 1 : 0) - (Input.GetKey(KeyCode.LeftShift) ? 1 : 0); // Space/Shift for moving up/down

        // Get input for pitch, yaw, and roll
        float pitchInput = (Input.GetKey(KeyCode.I) ? 1 : 0) - (Input.GetKey(KeyCode.K) ? 1 : 0);
        float yawInput = (Input.GetKey(KeyCode.L) ? 1 : 0) - (Input.GetKey(KeyCode.J) ? 1 : 0);
        float rollInput = (Input.GetKey(KeyCode.E) ? 1 : 0) - (Input.GetKey(KeyCode.Q) ? 1 : 0);

        // Move the plane based on vertical, horizontal, and lift input
        Vector3 direction = new Vector3(horizontalInput, liftInput, verticalInput).normalized;
        transform.Translate(direction * speed * Time.deltaTime, Space.Self);

        // Apply pitch (up/down rotation)
        transform.Rotate(Vector3.right, pitchInput * rotationSpeed * Time.deltaTime);

        // Apply yaw (left/right rotation)
        transform.Rotate(Vector3.up, yawInput * rotationSpeed * Time.deltaTime);

        // Apply roll (tilt left/right)
        transform.Rotate(Vector3.forward, -rollInput * rotationSpeed * Time.deltaTime);
    }
}

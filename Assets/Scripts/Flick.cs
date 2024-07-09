using UnityEngine;

public class FlickObject : MonoBehaviour
{
    public float forceMultiplier = 50f; // Adjust this value to apply more or less force
    public float rotationSpeed = 5f; // Adjust this value to control the rotation speed

    private Rigidbody rb; // Reference to the Rigidbody component

    void Start()
    {
        // Get the Rigidbody component from the game object
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(enabled) {
            // Check if the left mouse button was clicked
            if (Input.GetMouseButtonDown(0)) // 0 is the left mouse button
            {
                // Convert the mouse position from screen coordinates to world coordinates
                Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane - Camera.main.transform.position.z));

                // Calculate the direction from the game object to the mouse position
                Vector3 direction = mouseWorldPosition - transform.position;
                direction.y = 0; // This ensures the force and rotation are applied horizontally

                // Normalize the direction vector to have a magnitude of 1
                direction.Normalize();

                // Apply a force to the Rigidbody in the direction of the mouse position
                rb.AddForce(direction * forceMultiplier * Time.deltaTime, ForceMode.Impulse);

                // Calculate the target rotation based on the direction vector
                Quaternion targetRotation = Quaternion.LookRotation(direction);

                // Smoothly rotate towards the target rotation
                rb.rotation = Quaternion.Slerp(rb.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}

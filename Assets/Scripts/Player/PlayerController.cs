using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public CharacterController playerController; // Character controller that will respond to player inputs
    public Transform playerCamera; // Camera object that will tie to player movement

    public static bool isIdle = true;
    public static bool isWalking = false;
    
    public float speed = 6f; // Character movement speed.

    public float turnSmoothTime = 0.1f; // Smoothing time when player turns
    private float turnSmoothVelocity; // Container for angle dampening function


    // Update is called once per frame
    void Update()
    {
        // Define horizontal and vertical input sources
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // Define movement direction based on horizontal and vertical inputs
        Vector3 direction = new Vector3(horizontal, 0f, vertical);

        // When the direction has a magnitude, movement occurs
        if (direction.magnitude >= 0.1f)
        {
            isIdle = false;
            isWalking = true;
            // Rotate player to face movement direction
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + playerCamera.eulerAngles.y; // Define angle toward which player should look when moving
            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime); // Math sorcery to smooth the facing angle
            transform.rotation = Quaternion.Euler(0f, smoothAngle, 0f); // Rotate player

            // Move player in the direction they are facing
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward; // Make movement direction relative to camera/facing
            playerController.Move(moveDirection * speed * Time.deltaTime); // Player movement through game space
        }

        // When no other movement-related inputs are present, the player is idle
        else
        {
            isIdle = true;
            isWalking = false;
        }
    }
}

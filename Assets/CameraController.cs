using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 10f;     // Speed at which the camera moves
    public float rotateSpeed = 5f;    // Speed at which the camera rotates
    public float verticalSpeed = 5f;  // Speed at which the camera moves up and down

    private void Update()
    {
        // Camera movement on X and Z axes
        float horizontal = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        // Camera movement on Y axis (up and down)
        float verticalUpDown = 0f;
        if (Input.GetKey(KeyCode.Q))  // Move camera up when 'Q' is pressed
        {
            verticalUpDown = verticalSpeed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.E))  // Move camera down when 'E' is pressed
        {
            verticalUpDown = -verticalSpeed * Time.deltaTime;
        }

        // Apply movement to the camera
        transform.Translate(horizontal, verticalUpDown, vertical);

        // Camera rotation
        if (Input.GetMouseButton(1)) // Right mouse button for rotation
        {
            float mouseX = Input.GetAxis("Mouse X") * rotateSpeed;
            float mouseY = -Input.GetAxis("Mouse Y") * rotateSpeed;

            // Apply rotation to the camera
            transform.eulerAngles += new Vector3(mouseY, mouseX, 0);
        }
    }
}
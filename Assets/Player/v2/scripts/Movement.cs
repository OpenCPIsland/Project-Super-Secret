using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public Animator animator;

    void Start()
    {
    }

    void Update()
    {
        // Handle existing A/D key logic
        if (Input.GetKey(KeyCode.A))
        {
            Move(new Vector3(-movementSpeed, 0, 0));
            animator.SetBool("walking", true);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Move(new Vector3(movementSpeed, 0, 0));
            animator.SetBool("walking", true);
        }
        else
        {
            animator.SetBool("walking", false);
        }

        // Add left/right arrow key support
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Move(new Vector3(-movementSpeed, 0, 0));
            animator.SetBool("walking", true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            Move(new Vector3(movementSpeed, 0, 0));
            animator.SetBool("walking", true);
        }

        // Add touchscreen and mouse input support
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
            {
                // Check touch position
                if (touch.position.x < Screen.width / 2) // Left side of screen
                {
                    Move(new Vector3(-movementSpeed, 0, 0));
                    animator.SetBool("walking", true);
                }
                else if (touch.position.x > Screen.width / 2) // Right side of screen
                {
                    Move(new Vector3(movementSpeed, 0, 0));
                    animator.SetBool("walking", true);
                }
            }

            if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
            {
                animator.SetBool("walking", false);
            }
        }
        else if (Input.GetMouseButton(0)) // Left mouse button held
        {
            Vector3 mousePosition = Input.mousePosition;

            if (mousePosition.x < Screen.width / 2) // Left side of screen
            {
                Move(new Vector3(-movementSpeed, 0, 0));
                animator.SetBool("walking", true);
            }
            else if (mousePosition.x > Screen.width / 2) // Right side of screen
            {
                Move(new Vector3(movementSpeed, 0, 0));
                animator.SetBool("walking", true);
            }
        }
        else if (Input.GetMouseButtonUp(0)) // Left mouse button released
        {
            animator.SetBool("walking", false);
        }
    }

    void Move(Vector3 movement)
    {
        transform.position += movement;
        // Change facing direction
        if (movement.x > 0)
        {
            // Set the rotation to 180 degrees around the Y-axis
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 180, transform.rotation.eulerAngles.z);
        }
        else if (movement.x < 0)
        {
            // Set the rotation to 0 degrees around the Y-axis
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, transform.rotation.eulerAngles.z);
        }
    }
}

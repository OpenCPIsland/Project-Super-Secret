using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            Move(new Vector3(-movementSpeed, 0, 0));
            animator.SetBool("walking", true);
        } else if (Input.GetKey(KeyCode.D)) 
        { 
            Move(new Vector3(movementSpeed, 0));
            animator.SetBool("walking", true);
        } else
        {
            animator.SetBool("walking", false);
        }

    }

    void Move(Vector3 movement)
    {
        transform.position += movement;
        //Change facing direction
        if (movement.x > 0)
        {
            // Set the rotation to 180 degrees around the Y-axis
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 180, transform.rotation.eulerAngles.z);
        }
        else
        {
            // Set the rotation to 0 degrees around the Y-axis
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, 0, transform.rotation.eulerAngles.z);
        }
    }
}

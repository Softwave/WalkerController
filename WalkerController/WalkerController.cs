// Minimal fps controller

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerController : MonoBehaviour
{
    public CharacterController controller; 
    public float walkSpeed = 6.0f;
    public float runSpeed = 10.0f; 
    public float gravity = -9.81f; 
    public bool enableRunning = false;
    public float jumpHeight = 4.0f; 

    private bool grounded;
    private float speed;
    private Vector3 moveDirection = Vector3.zero;
    private Vector3 velocity; 

    void Start() 
    {
        speed = walkSpeed;
    }

    void Update() 
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        moveDirection = transform.right * inputX + transform.forward * inputY;

        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;

        if (CollisionFlags.Below != 0) {
            grounded = true; 
        } else {
            grounded = false; 
        }

        if (enableRunning)
        {
            speed = Input.GetButton("Run") ? runSpeed : walkSpeed;
        }

        // Finally, move 
        controller.Move(moveDirection * speed * Time.deltaTime);
        controller.Move(velocity * Time.deltaTime);
    }
}

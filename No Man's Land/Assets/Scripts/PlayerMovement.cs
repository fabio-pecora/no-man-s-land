using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    Vector3 velocity;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;
    public float jumpHeight = 3f;
    public Vector3 originalPos;

    bool isGrounded;
    // Update is called once per frame

    private void Start()
    {
        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
        if (Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        // check if the player is falling
        if(this.gameObject.transform.position.y <= -150)
        {
            // place him back to the original position
            gameObject.transform.position = originalPos;
            Timer.secondsLeft = 25;

        }

        if(Timer.secondsLeft <= 0)
        {
            gameObject.transform.position = originalPos;
            Timer.secondsLeft = 25;
        }
    }

}

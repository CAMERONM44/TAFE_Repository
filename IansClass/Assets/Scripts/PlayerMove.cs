using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private CharacterController controller;
    [SerializeField] private Transform camContainer;
    [SerializeField] private Vector3 playerVelocity;
    private bool groundedPlayer;
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;
    [SerializeField] private float rotSpeed;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    private void Update()
    {
        //set the groundedPlayer bool to match the isGrounded value in the controller component
        groundedPlayer = controller.isGrounded;

        //check if the player in grounded
        //and if the y value of their velocity is less than 0
        if (groundedPlayer && playerVelocity.y < 0 )
        {
            playerVelocity.y = 0f;
        }

        //detect player input for horizontal and vertical movement
        //multiply it by playerSpeed
        //assign result to local variables for horizontal and vertical
        float horizontal = Input.GetAxis("Horizontal") * playerSpeed;
        float vertical = Input.GetAxis("Vertical") * playerSpeed;

        //create local Vector3 variable
        //multiply the horizontal and vertical inputs by the camera containers .right and .forward values to determine direction
        Vector3 move = camContainer.right * horizontal + camContainer.forward * vertical;

        //apply the movement to the controller, multiplying by deltaTime and playerSpeed
        controller.Move(move * Time.deltaTime * playerSpeed);

        //detect input from player for jumping
        //check if they are grounded
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            //have the player object jump by using Math.Sqrt to 
            //apply the jumpHeight adjusted with the gravityValue to playerVelocity.y
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }
        //constantly apply gravityValue to playerVelocity.y for falling due to gravity
        //use controller.Move() to apply this
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        //detect input for turning
        //apply the value from the input to local float variable
        float rotationInput = Input.GetAxis("Rotate");

        //check if the rotationInput local variable is anything other than 0
        if (rotationInput != 0)
        {
            //rotate the player object using transform.Rotate() method
            //do this relative to it's own 'up' direction, multiplying the values by the rotation speed variable
            //also multiply by deltatime to smooth it out
            transform.Rotate(Vector3.up * rotationInput * rotSpeed * 10 * Time.deltaTime);
        }
        
    }
}

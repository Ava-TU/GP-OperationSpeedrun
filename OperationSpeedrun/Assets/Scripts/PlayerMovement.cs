using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

public float speed;
public float rotationSpeed;
public float jumpSpeed;

private CharacterController characterController;
private float ySpeed; //Keeps track of the speed in the Y direction & increase this when the player jumps and decrease due to the gravity
private float originalStepOffset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float magnitude = Mathf.Clamp01(movementDirection.magnitude) * speed; //Ensures the player speeds stays capped at the chosen speed variable amount
        movementDirection.Normalize(); //Stops the directional movement increasing speed

        ySpeed += Physics.gravity.y * Time.deltaTime; //Getting gravity value and adding it to the Y value every second per frame

        if (characterController.isGrounded) //Player only jumps if the controller is on the ground
        {
            ySpeed = -0.5f; //This helps to "keep" the player on the ground, so that I can constantly press jump and have it work properly
            characterController.stepOffset = originalStepOffset;

            if (Input.GetButtonDown("Jump"))
            {
                ySpeed = jumpSpeed;
            }
        }
        else
        {
            characterController.stepOffset = 0;
        }
        
        Vector3 velocity = movementDirection * magnitude;
        velocity.y = ySpeed;

        characterController.Move(velocity * Time.deltaTime); //Time.deltaTime makes sure the player moves at the same speed regardless of framerate

        if (movementDirection != Vector3.zero) //Checks if player is moving
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up); //Rotates the player to the direction of the movement input

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime); //Rotates towards the above direction according to the rotation speed variable
        }
    }
}

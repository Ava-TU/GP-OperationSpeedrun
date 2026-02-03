using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

public float rotationSpeed;
public float jumpSpeed;
public float jumpGracePeriod; //This will be used to allow the player to jump if they press the jump button a fraction too early/late to improve the game feel :)

private Animator animator;
private CharacterController characterController;
private float ySpeed; //Keeps track of the speed in the Y direction & increase this when the player jumps and decrease due to the gravity
private float originalStepOffset;
private float? lastGroundedTime; //The ? means that it can either contain a float value or no value at all
private float? jumpButtonPressedTime;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();

        characterController = GetComponent<CharacterController>();
        originalStepOffset = characterController.stepOffset;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical"); //Gets the input values for these keys 

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        float inputMagnitude = Mathf.Clamp01(movementDirection.magnitude);

        if (Input.GetKey(KeyCode.LeftShift) == false && Input.GetKey(KeyCode.RightShift) == false)
        {
            inputMagnitude /= 2;
        }

        animator.SetFloat("Input Magnitude", inputMagnitude, 0.05f, Time.deltaTime); //This controls the blending between the animations

        movementDirection.Normalize(); //Stops the directional movement increasing speed

        ySpeed += Physics.gravity.y * Time.deltaTime; //Getting gravity value and adding it to the Y value every second per frame

        if (characterController.isGrounded)
        {
            lastGroundedTime = Time.time;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpButtonPressedTime = Time.time;
        }

        if (Time.time - lastGroundedTime <= jumpGracePeriod) //Player only jumps if the controller is on the ground
        {
            ySpeed = -0.5f; //This helps to "keep" the player on the ground, so that I can constantly press jump and have it work properly
            characterController.stepOffset = originalStepOffset;

            if (Time.time - jumpButtonPressedTime <= jumpGracePeriod)
            {
                ySpeed = jumpSpeed;
                jumpButtonPressedTime = null;
                lastGroundedTime = null; //Setting these back to null makes sure the player doesnt jump repeatedly during the grace period
            }
        }
        else
        {
            characterController.stepOffset = 0;
        }
        

        if (movementDirection != Vector3.zero) //Checks if player is moving
        {
            //animator.SetBool("isMoving", true); //If the player is moving, sets the animator bool to true, transitioning from idle to running
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up); //Rotates the player to the direction of the movement input

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime); //Rotates towards the above direction according to the rotation speed variable
        }
        else
        {
            //animator.SetBool("isMoving", false); //This transitions the running animation back to the idle one
        }
    }
    private void OnAnimatorMove()
        {
             Vector3 velocity = animator.deltaPosition;
            velocity.y = ySpeed * Time.deltaTime; //Combines the animation position change with the calculated ySpeed

            characterController.Move(velocity);
        }
}

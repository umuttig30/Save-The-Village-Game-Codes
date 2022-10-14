using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private CharacterController playerController;
    [Header("Move")]
    [SerializeField]
    private float turnSpeed = 150;
    [SerializeField]
    private float forwardMoveSpeed = 7.5f;
    [SerializeField]
    private float backwardMoveSpeed = 3f;

    [Header("Jump")]
    [SerializeField]
    private float jumpStrength = 0.4f;
    private float jumpAccerelation = 0;
    private int jumpCount = 0;
    private float horizontal;
    private float vertical;

    private Animator animator;

    void Awake()
    {
        playerController = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        MouseKeyboardInputs();
        Movements();
    }
    private void MouseKeyboardInputs()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpCount < 2)
            {
                jumpAccerelation = jumpStrength;

                jumpCount += 1;
            }
        }
    }
    private void Movements()
    {
        animator.SetFloat("runningSpeed", vertical);
        animator.SetFloat("jumpingSpeed", jumpAccerelation);

        transform.Rotate(Vector3.up, horizontal * turnSpeed * Time.deltaTime);

        if (vertical != 0)
        {
            float moveSpeedToUse = (vertical > 0) ? forwardMoveSpeed : backwardMoveSpeed;
            playerController.SimpleMove(transform.forward * moveSpeedToUse * vertical); 
        }

        if (jumpAccerelation != 0)
        {
            Vector3 jumping = new Vector3(0, jumpAccerelation, 0);
            playerController.Move(jumping);
        }

        if (playerController.isGrounded)
        {
            jumpCount = 0;
        }
        if (jumpAccerelation > vertical - 0.98f)
        {
            jumpAccerelation = Mathf.MoveTowards(jumpAccerelation,-0.98f , Time.deltaTime * 2);
        }
    }
}

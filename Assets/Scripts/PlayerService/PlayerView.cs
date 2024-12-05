using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] Transform playerCamera;
    [SerializeField] int mouseSensitivity;
    [SerializeField] float movementSpeed;
    [SerializeField] float jumpSpeed;
    [SerializeField] float gravity;
    [SerializeField] Transform groundCheckTransform;
    [SerializeField] float groundCheckRadius;
    [SerializeField] LayerMask groundLayerMask;
    private PlayerController playerController;
    private bool isGrounded;


    private void Start()
    {
        Cursor.lockState=CursorLockMode.Locked;
    }
    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheckTransform.position, groundCheckRadius, groundLayerMask);
        float mouseX = Input.GetAxisRaw("Mouse X");
        float mouseY = Input.GetAxisRaw("Mouse Y");
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        bool jump = Input.GetButtonDown("Jump");


        playerController.RotatePlayer(mouseX, mouseY,playerCamera);
        playerController.MovePlayer(horizontal,vertical,isGrounded);
        if (isGrounded) { playerController.PerformJump(jump); }
    }

    public void SetController(PlayerController playerController)
    {
        this.playerController = playerController;
        playerController.SetMouseSensitivity(mouseSensitivity);
        playerController.SetCharacterController(this.gameObject.GetComponent<CharacterController>());
        playerController.SetMovementSpeed(movementSpeed);
        playerController.SetGravity(gravity);
        playerController.SetJumpSpeed(jumpSpeed);
    }
}

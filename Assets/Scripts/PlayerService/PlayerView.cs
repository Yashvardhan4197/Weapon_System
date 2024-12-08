
using UnityEngine;

public class PlayerView : MonoBehaviour,IDamageAble
{
    [SerializeField] Transform playerCamera;
    [SerializeField] int mouseSensitivity;
    [SerializeField] float movementSpeed;
    [SerializeField] float jumpSpeed;
    [SerializeField] float gravity;
    [SerializeField] Transform groundCheckTransform;
    [SerializeField] float groundCheckRadius;
    [SerializeField] LayerMask groundLayerMask;
    [SerializeField] Transform aimPosition;
    private PlayerController playerController;
    private bool isGrounded;

    [SerializeField] Transform crossHairObject;
    Ray ray;
    RaycastHit hit;

    private void Start()
    {
        Cursor.lockState=CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        if (playerController.GetPuseStatus() == false)
        {
            ray.origin = playerCamera.position;
            ray.direction = playerCamera.forward;
            Physics.Raycast(ray, out hit);
            crossHairObject.transform.position = hit.point;
            playerController.SetCrossHairObjectPosition(crossHairObject.transform);

            isGrounded = Physics.CheckSphere(groundCheckTransform.position, groundCheckRadius, groundLayerMask);
            float mouseX = Input.GetAxisRaw("Mouse X");
            float mouseY = Input.GetAxisRaw("Mouse Y");
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            bool jump = Input.GetButtonDown("Jump");

            CheckWeaponSpawner();

            playerController.RotatePlayer(mouseX, mouseY, playerCamera);
            playerController.MovePlayer(horizontal, vertical, isGrounded);
            if (isGrounded) { playerController.PerformJump(jump); }
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            playerController.OnEscapeKeyClicked();
        }
    }

    private void CheckWeaponSpawner()
    {
        if(Input.GetKey(KeyCode.Alpha1))
        {
            playerController.SpawnWeapon(1);
        }else if (Input.GetKey(KeyCode.Alpha2))
        {
            playerController.SpawnWeapon(2);
        }else if(Input.GetKey(KeyCode.Alpha3))
        {
            playerController.SpawnWeapon(3);
        }else if(Input.GetKey(KeyCode.Alpha4))
        {
            playerController.SpawnWeapon(4);
        }
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

    public void TakeDamage(float damage)
    {
        playerController.TakeDamage(damage);
    }
}

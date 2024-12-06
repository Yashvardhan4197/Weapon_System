using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController
{
    private PlayerView playerView;
    private Transform playerTransform;
    private Transform playerCamera;
    private CharacterController characterController;
    private Transform crossHairPosition;
    private float xRotation;
    private float velocity;
    private float gravity;
    private float movementSpeed;
    private int mouseSensitivity;
    private float jumpSpeed;
    private bool isJumped;
    public int MouseSensitivity { get { return mouseSensitivity; } }
    public float MovementSpeed { get { return movementSpeed; } }
    public Transform PlayerTransform { get { return playerTransform; } }


    public PlayerController(PlayerView playerView)
    {
        this.playerView = playerView;
        xRotation = 0;
        playerTransform=playerView.transform;
        playerView.SetController(this);
    }

    public void RotatePlayer(float mouseX, float mouseY, Transform playerCamera)
    {
        mouseY*=mouseSensitivity*Time.deltaTime;
        xRotation -= mouseY;
        xRotation=Mathf.Clamp(xRotation, -90f, 90f);
        playerCamera.localRotation=Quaternion.Euler(xRotation, 0, 0);

        playerTransform.Rotate(Vector3.up*mouseX);
    }

    public void MovePlayer(float horizontal, float vertical,bool isGrounded)
    {

        if(isGrounded&&velocity<0)
        {
            velocity = -2f;
        }

        Vector3 moveDown=Vector3.up*velocity*Time.deltaTime;
        characterController.Move(moveDown*Time.deltaTime);

        Vector3 move = (playerTransform.right * movementSpeed) * horizontal + playerTransform.forward * vertical * movementSpeed;
        characterController.Move(move);
        velocity += gravity*Time.deltaTime;

    }

    public void SetMouseSensitivity(int mouseSensitivity)
    {
        this.mouseSensitivity = mouseSensitivity;
    }

    public void SetMovementSpeed(float movementSpeed)
    {
        this.movementSpeed = movementSpeed;
    }

    public void SetCharacterController(CharacterController characterController)
    {
        this.characterController = characterController;
    }

    public void SetGravity(float gravity)
    {
        this.gravity = gravity;
    }

    public void PerformJump(bool jump)
    {
        if(jump)
        {
            velocity = jumpSpeed;

        }
    }

    public void SetJumpSpeed(float jumpSpeed)
    {
        this.jumpSpeed = jumpSpeed;
    }

    public void SpawnWeapon(int weaponNumber)
    {
        GameService.Instance.WeaponService.UseWeapon(weaponNumber);
    }

    public Transform GetCrossHairObjectPositon() => crossHairPosition;

    public void SetCrossHairObjectPosition(Transform crossHairPosition)=>this.crossHairPosition = crossHairPosition;

}

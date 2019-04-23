using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //movement
    [SerializeField] private string horizontalInputName;
    [SerializeField] private string verticalInputName;
    [SerializeField] private float movementSpeed;

    private CharacterController charController;

    //jump
    [SerializeField] private AnimationCurve jumpFallOff;
    [SerializeField] private float jumpMultiplier;
    [SerializeField] private KeyCode jumpKey;
    private bool isJumping;

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
       }


    private void Update()
    {
        PlayerMovements();

    }

    private void PlayerMovements()
    {
        float horiztInput = Input.GetAxis(horizontalInputName) * movementSpeed;
        float vertInput = Input.GetAxis(verticalInputName) * movementSpeed;

        Vector3 fowardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horiztInput;

        charController.SimpleMove(fowardMovement + rightMovement); 

        JumpInput();

    }


    private void JumpInput()
    {
        if (Input.GetKeyDown(jumpKey) && !isJumping)
        {
            isJumping = true;
            StartCoroutine(JumpEvent()); // start coroutine 
        }
    }

    private IEnumerator JumpEvent()
    {
        charController.slopeLimit = 90.0f; 
        float timeInAir = 0.0f;

        do
        {
            float jumpForce = jumpFallOff.Evaluate(timeInAir);
            charController.Move(Vector3.up * jumpForce * jumpMultiplier * Time.deltaTime);
            timeInAir += Time.deltaTime;
            yield return null;
        } while (!charController.isGrounded && charController.collisionFlags != CollisionFlags.Above); //while not in ground and with nothing above

        charController.slopeLimit = 45.0f;
        isJumping = false;
    }


}

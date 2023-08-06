using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Objects")]
    [SerializeField] private  JoystickController joystickController;
    private CharacterController characterController;

    [Header("Settings")]
    [SerializeField] private float moveSpeed;
     Vector3 moveVector;

    [Header("Scripts")]
    [SerializeField] private PlayerAnimationContol playerAnimationContol;
    




    // Start is called before the first frame update
    void Start()
    {
        characterController=GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
    }

    private void movePlayer()
    {
        moveVector = joystickController.getMovePosition() * moveSpeed * Time.deltaTime;

        moveVector.z = moveVector.y;
        moveVector.y = 0;

        characterController.Move(moveVector);
        playerAnimationContol.AnimControl(moveVector);
         
    }
}

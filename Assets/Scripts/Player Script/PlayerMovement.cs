using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //define character controller
    private CharacterController character_Controller;

    //define calculate move direction
    private Vector3 move_Direction;

    //define speed
    public float speed = 5f;
    
    //define gravity
    private float gravity = 20f;

    //define how much jump
    public float jump_Force = 10f;
    
    //
    private float vertical_Velocity;

    //unity Function awake
    private void Awake()
    {
        //get component controller from unity (see unity inspector panel)
        character_Controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveThePlayer();
    }

    //control move player
    void MoveThePlayer()
    {
        //create new object vector with construct axis movement
        move_Direction = new Vector3(Input.GetAxis(Axis.HORIZONTAL), 0f, 
                                    Input.GetAxis(Axis.VERTICAL));

        move_Direction = transform.TransformDirection(move_Direction);
        move_Direction *= speed * Time.deltaTime;

        ApplyGravity();

        character_Controller.Move(move_Direction);
        // for key A-D
        //print("Horizontal: " + Input.GetAxis("Horizontal"));
    }

    // apply gravity
    void ApplyGravity()
    {
        vertical_Velocity -= gravity * Time.deltaTime;

        //jump
        PlayerJump();

        move_Direction.y = vertical_Velocity * Time.deltaTime;


        /*if (character_Controller.isGrounded)
        {

            vertical_Velocity -= gravity * Time.deltaTime;

            //jump
            PlayerJump();
        }
        else
        {
            vertical_Velocity -= gravity * Time.deltaTime;
        }*/

        //move_Direction.y = vertical_Velocity;
    }

    void PlayerJump()
    {
        if (character_Controller.isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            print("press space " + Input.GetKeyDown(KeyCode.Space));
            vertical_Velocity =  jump_Force;
        }
    }

    // Start is called before the first frame update
    //void Start() { }
}

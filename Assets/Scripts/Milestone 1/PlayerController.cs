//Player Controller: Controls for the player

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Get Pawn class
    public Pawn pawn;
    public Weapon weapon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        HandleShooting();
        //True to Jump
        if (Input.GetKey(KeyCode.Space))
        {
            //Set Jump true when hit the key to play animation
            pawn.anim.SetBool("Jump", true);
        }
        
        //Nothing if false
        else
        {
            pawn.anim.SetBool("Jump", false);
        }
        //Crouch Key

        //Crouch if true to play crouch animation
        if (Input.GetKey(KeyCode.C))
        {
            //Calls the Crouch state
            pawn.anim.SetBool("Crouch", true);
        }
        //Nothing if false
        else
        {
            pawn.anim.SetBool("Crouch", false);
        }
    }
    //Movement Function
    void Movement()
    {
        //Vector 2 inputs
        pawn.Move(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));

        //Walk Key
        if (Input.GetKey(KeyCode.LeftControl))
        {
            if (pawn.currentSpeed >= .2)
            {
                pawn.currentSpeed -= .01f;
            }
        }
        //Sprint Key
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            if (pawn.currentSpeed <= 2)
            {
                pawn.currentSpeed += .01f;
            }
        }
        //If nothing happen, went to run speed
        else
        {
            pawn.currentSpeed = 1f;
        }
    }
    private void HandleShooting()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            pawn.OnTriggerPull.Invoke();
        }
        if (Input.GetButtonUp("Fire1"))
        {
            pawn.OnTriggerRelease.Invoke();
        }
    }
}

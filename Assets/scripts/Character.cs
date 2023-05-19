using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Character : MonoBehaviour
{

   public CharacterController controller;
    public Vector3 movementveocity;

    public float movespeed = 5f;

    public Playerinput playerinput;

    public float verticalVelocity;

    public float Gravity = -9.8f;

    private void Awake()
    {
        controller= GetComponent<CharacterController>();
        playerinput= GetComponent<Playerinput>();
    }

   private void CalculatePlayermovment()
    {
        movementveocity.Set(playerinput.Horizontalinput, 0f, playerinput.Verticalinput);
        movementveocity.Normalize();
        movementveocity = Quaternion.Euler(10f,2f, 0) * movementveocity;
        movementveocity *= movespeed*Time.deltaTime;

        if(movementveocity != Vector3.zero)
        transform.rotation = Quaternion.LookRotation(movementveocity);

    }

    private void FixedUpdate()
    {
        CalculatePlayermovment();
        if (controller.isGrounded == false)
            verticalVelocity = Gravity;
        else
            verticalVelocity = Gravity*0.3f;

        movementveocity += verticalVelocity * Vector3.up * Time.deltaTime; 


        controller.Move(movementveocity);
    }


}

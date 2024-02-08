using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
 
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] private float baseSpeed = 70f;
    [SerializeField] private float boostedSpeed = 100f;

    private bool canMove = true;
     
    Rigidbody2D rb2d;
    private SurfaceEffector2D surfaceEffector2d;
    
     void Start()
    {
       rb2d = GetComponent<Rigidbody2D>();
       surfaceEffector2d = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {
            TorqueOfPlayerMovement();
            RespondToBoost();
        }
    }
    public void DisableMove()
    {
        canMove = false;
    }
   
    void TorqueOfPlayerMovement()
    {
        if(Input.GetKey(KeyCode.LeftArrow)){
            rb2d.AddTorque(torqueAmount);
        }else if (Input.GetKey(KeyCode.RightArrow)){
            rb2d.AddTorque(-torqueAmount);
        }
    }

    void RespondToBoost()
    {
        if (Input.GetKey((KeyCode.UpArrow)))
        {
            surfaceEffector2d.speed = boostedSpeed;
        }else
        {
            surfaceEffector2d.speed = baseSpeed;
        }
    }

    
}

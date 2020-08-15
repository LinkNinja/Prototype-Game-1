using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public GameObject turret;
    public GameObject projectile;
    //private variables

    [SerializeField] float _tankSpeed;
    [SerializeField] private float horsePower = 0;
    private float _turnSpeed = 45.0f;
    private float _horizontalInput;
    private float _forwardInput;
    private Rigidbody playerRb;
    [SerializeField] GameObject centerOfMass;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] float rpm;
    [SerializeField] List<WheelCollider> allWheels;
    [SerializeField] int wheelsOnGround;

    private void Start()
    {
        //Our playerRb variable is set to the rigid body component that is on the vehicle when the game starts
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        //Here we are getting the transform component of our object. This would be the vehicles transform.
        // We'll move the vehicle forward.
        //Using (x, y, z,)
        //transform.Translate(0, 0, 1);
        //Vector.forward translates to Translate(0,0,1)

        //Updating the vehicle to move forward based on time passing instead of frames per second.
        //Important due to the fact that some players machines cannot run 60fps 30fps etc.

        //We move vehicle Forward
        //transform.Translate(Vector3.forward * Time.deltaTime * _tankSpeed * _forwardInput);
        // We turn the vehicle

        //This is where we get player input.
        _horizontalInput = Input.GetAxis("Horizontal");
        //Using the input manager from unity to create an assign a variable
        _forwardInput = Input.GetAxis("Vertical");

        if (isOnGround())
        {

            playerRb.AddRelativeForce(Vector3.forward * horsePower * _forwardInput);
            transform.Rotate(Vector3.up, Time.deltaTime * _turnSpeed * _horizontalInput);
            _tankSpeed = Mathf.RoundToInt(playerRb.velocity.magnitude * 2.237f); // for KPH change 2.237 to 3.6

            speedometerText.SetText("Speed: " + _tankSpeed + "mph");
            rpm = Mathf.Round((_tankSpeed % 30) * 40);
            rpmText.SetText("RPM: " + rpm);
        }
        
        //Rotate the turret Right
        if (Input.GetKey(KeyCode.E))
        {
            turret.transform.Rotate(Vector3.up, Time.deltaTime * _turnSpeed);
            //Stop turret from hitting antenna

        }
        //Rotate the turret left
        if (Input.GetKey(KeyCode.Q))
        {
            turret.transform.Rotate(Vector3.down, Time.deltaTime * _turnSpeed);
            //stop turret from hitting antenna
        }

        //Speed tank up with Page Up
        if(Input.GetKey(KeyCode.T))
        {
            //_tankSpeed += Time.deltaTime * 1;
        }

        // Slow down tank with page downr
        if(Input.GetKey(KeyCode.R))
        
        {
            //_tankSpeed -= Time.deltaTime * 1;
        }


        //Launch Projectile
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    Instantiate(projectile.transform.position);
        //    projectile.transform.Translate(Vector3.down  * _turnSpeed);
        //}
        






    }

    bool isOnGround()
    {
        wheelsOnGround = 0;
        foreach(WheelCollider wheel in allWheels)
        {
            if(wheel.isGrounded)
            {
                wheelsOnGround++;
            }
        }
        if(wheelsOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }

    }

}

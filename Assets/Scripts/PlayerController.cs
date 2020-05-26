using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject turret;
    public GameObject projectile;
    //private variables
    public float _tankSpeed = 5.0f;
    public float _turnSpeed = 15.0f;
    public float _horizontalInput;
    public float _forwardInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //This is where we get player input.
        _horizontalInput = Input.GetAxis("Horizontal");
        //Using the input manager from unity to create an assign a variable
        _forwardInput = Input.GetAxis("Vertical");
        

        //Here we are getting the transform component of our object. This would be the vehicles transform.
        // We'll move the vehicle forward.
        //Using (x, y, z,)
        //transform.Translate(0, 0, 1);
        //Vector.forward translates to Translate(0,0,1)

        //Updating the vehicle to move forward based on time passing instead of frames per second.
        //Important due to the fact that some players machines cannot run 60fps 30fps etc.

        //We move vehicle Forward
        transform.Translate(Vector3.forward * Time.deltaTime * _tankSpeed * _forwardInput);
        // We turn the vehicle
        transform.Rotate(Vector3.up,  Time.deltaTime * _turnSpeed * _horizontalInput);

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
            _tankSpeed += Time.deltaTime * 1;
        }

        // Slow down tank with page down
        if(Input.GetKey(KeyCode.R))
        
        {
            _tankSpeed -= Time.deltaTime * 1;
        }


        //Launch Projectile
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    Instantiate(projectile.transform.position);
        //    projectile.transform.Translate(Vector3.down  * _turnSpeed);
        //}
        






    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject player;
    private Vector3 _offset = new Vector3(0, 5, -5);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Offset the camera behind the player by adding to the players position
        transform.position = player.transform.position + _offset;

        //Here you can change camera view of your vehicle or player.. REMEMBER THIS SCRIPT
        /*
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _offset = new Vector3(0, 5, -10);

            
        }
        else if (Input.GetKeyDown(KeyCode.Space) && _offset == new Vector3(0, 5, -10))
        {
            _offset = new Vector3(0, 5, -15);
        }
        */
    }
}

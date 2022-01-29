using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{

    private Transform player;
    public float cameraSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // get the player if we don't already have one
        if (player == null)
        {
            try
            {
                player = GameObject.Find("Player(Clone)").transform;
            }
            catch
            {
                print("No player to be found!");
            }
        }

        // floats the camera towards the player 
        else
        {
            Vector3 dummyPos = transform.position;
            dummyPos.z = 0;
            dummyPos = Vector2.Lerp(dummyPos, player.position, Time.deltaTime * cameraSpeed);
            dummyPos.z = -8;
            transform.position = dummyPos;
        }
    }
}

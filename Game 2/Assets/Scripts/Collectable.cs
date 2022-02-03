 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public InfectionRate infectionRate;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //collision
        if (collision.gameObject.tag == "Player")
        {
            //check if Vaccine or Pills
            if(gameObject.tag == "Vaccine")
            {
                infectionRate.currentInfection = 0;
                Debug.Log("Got");
            }
            else if (gameObject.tag == "Pills")
            {
                if(infectionRate.currentInfection >= 10)
                {
                    infectionRate.currentInfection -= 10;
                }
                else
                {
                    infectionRate.currentInfection = 0;
                }
                Debug.Log("Got");
            }
            Destroy(gameObject);
        }
    }
}

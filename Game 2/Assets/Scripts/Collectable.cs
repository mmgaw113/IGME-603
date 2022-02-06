 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        //collision
        if (collision.gameObject.CompareTag("Player"))
        {
            //check if Vaccine or Pills
            if(gameObject.CompareTag("Vaccine"))
            {
                collision.transform.GetComponent<InfectionRate>().currentInfection = 0;
                Debug.Log("Got");
            }
            else if (gameObject.CompareTag("Pills"))
            {
                if(collision.transform.GetComponent<InfectionRate>().currentInfection >= 10)
                {
                    collision.transform.GetComponent<InfectionRate>().currentInfection -= 10;
                }
                else
                {
                    collision.transform.GetComponent<InfectionRate>().currentInfection = 0;
                }
                Debug.Log("Got");
            }
            Destroy(gameObject);
        }
    }
}

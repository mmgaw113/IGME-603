using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infector : MonoBehaviour
{
    InfectionRate playerRate;

    // Start is called before the first frame update
    void Start()
    {
        //playerRate.GetComponentInParent<InfectionRate>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
            collision.GetComponent<EnemyController>().InfectEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

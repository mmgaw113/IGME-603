using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startPoint : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        // player = (GameObject)Resources.Load("Assets/Prefabs/Player", typeof(GameObject));
        Respawn();
    }

    public void Respawn()
    {
        GameObject.Instantiate(player, transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

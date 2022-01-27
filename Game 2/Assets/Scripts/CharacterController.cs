using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 10f;
    private float movement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       movement = Input.GetAxisRaw("Horizontal");
    }
    private void FixedUpdate()
    {
        transform.position += new Vector3(movement * speed * Time.deltaTime,0 ,0);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 10f;
    public LayerMask groundMask;

    private Rigidbody2D rb;
    private Transform groundCheckTransform;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundCheckTransform = gameObject.transform.GetChild(1);
    }

    // Update is called once per frame
    void Update()
    {
        // gets the inputs we need
        float movement = Input.GetAxisRaw("Horizontal");
        bool jump = Input.GetButtonDown("Jump") && Physics2D.OverlapCircle(groundCheckTransform.position, 0.35f, groundMask);

        // changes the player's velocity for movement and jumping
        rb.velocity = rb.velocity + new Vector2(movement * speed - rb.velocity.x, jump ? jumpForce : 0);


    }

}


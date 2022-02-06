using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 10f;
    public LayerMask groundMask;
    public GameObject bullet;

    private Rigidbody2D rb;
    private Transform groundCheckTransform;
    private Transform hip;
    private Transform gun;
    private bool flipX = false;

    private Animator anim;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        groundCheckTransform = gameObject.transform.GetChild(1);

        hip = gameObject.transform.GetChild(3);
        gun = hip.GetChild(0);

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // gets the inputs we need
        float movement = Input.GetAxisRaw("Horizontal");
        bool jump = Input.GetButtonDown("Jump") && Physics2D.OverlapCircle(groundCheckTransform.position, 0.25f, groundMask);
        if (Input.GetKeyDown(KeyCode.E))
        {
            shoot();
        }


        // changes the player's velocity for movement and jumping
        rb.velocity = rb.velocity + new Vector2(movement * speed - rb.velocity.x, jump ? jumpForce : 0);

        //Animation Controlling
        if (Mathf.Abs(rb.velocity.magnitude) > 0)
            anim.SetBool("IsWalking", true);
        else
            anim.SetBool("IsWalking", false);

        if (flipX && rb.velocity.x > 0 || !flipX && rb.velocity.x < 0)
        {
            flipX = !flipX;
            hip.localScale = new Vector3(flipX ? -1 : 1, 1, 1);
        }

        GetComponent<SpriteRenderer>().flipX = flipX;

    }

    void shoot()
    {
        print("Bang!");
        Instantiate(bullet, gun.position, gun.rotation).GetComponent<bullet>().left = flipX;
    }

}


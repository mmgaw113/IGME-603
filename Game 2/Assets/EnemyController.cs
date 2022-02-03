using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private int infected;
    private Rigidbody2D rb;

    public float waitTime;
    public LayerMask mask;
    public float speed;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        infected = 0;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (infected == 1)
        {
            waitInfection();
        }
        else if (infected == 2)
        {
            // chase the player
            chasePlayer();
        }
    }

    private void chasePlayer()
    {
        float targetDistance = 0;

        // checks to the right
        RaycastHit2D RightHit = Physics2D.Raycast(transform.position, Vector2.right, 20, mask);
        if (RightHit.point != new Vector2(0,0))
        {
            int RightHitLayer = RightHit.transform.gameObject.layer;
            if (RightHitLayer == 3 || RightHitLayer == 7) 
            {

                // there is a target to the right
                targetDistance = RightHit.distance;
            }
        }

        // checks to the left
        RaycastHit2D LeftHit = Physics2D.Raycast(transform.position, -Vector2.right, 20, mask);
        if (LeftHit.point != new Vector2(0, 0))
        {
            print("Left!");
            int LeftHitLayer = LeftHit.transform.gameObject.layer;
            if (LeftHitLayer == 3 || LeftHitLayer == 7)
            {
                // there is a target to the right
                targetDistance = targetDistance > LeftHit.distance || targetDistance == 0 ? -LeftHit.distance : targetDistance;
            }
        }


        // move toward the target
        if (targetDistance != 0)
            rb.velocity = rb.velocity - Vector2.right * rb.velocity.x + Vector2.right * speed * (targetDistance > 0 ? 1 : -1);

    }


    private void waitInfection()
    {
        if (waitTime > 0)
        {
            waitTime -= Time.deltaTime;
        }
        else
        {
            // become zombie
            infected = 2;
            spriteRenderer.color = Color.green;
            gameObject.layer = 6;
        }
    }

    public void InfectEnemy()
    {
        if (infected == 0)
        {
            infected = 1;
            Debug.Log("Success");
        }
    }
}

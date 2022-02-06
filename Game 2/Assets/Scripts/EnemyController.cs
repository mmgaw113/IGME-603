using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private int infected;
    private Rigidbody2D rb;
    private float lastTarget;

    public float waitTime;
    public LayerMask mask;
    public float speed;
    public float damage;

    private Animator anim;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        infected = 0;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
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
        else
            anim.SetBool("IsMoving", false);
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
            int LeftHitLayer = LeftHit.transform.gameObject.layer;
            if (LeftHitLayer == 3 || LeftHitLayer == 7)
            {
                // there is a target to the right
                targetDistance = targetDistance > LeftHit.distance || targetDistance == 0 ? -LeftHit.distance : targetDistance;
            }
        }


        if (targetDistance != 0)
        {
            // move toward the target
            rb.velocity = rb.velocity - Vector2.right * rb.velocity.x + Vector2.right * speed * (targetDistance > 0 ? 1 : -1);
            
            // flip the sprite
            spriteRenderer.flipX = targetDistance < 0;

            // save the last location of the target
            lastTarget = targetDistance > 1 ? 10 : -10;
        }
        else if (lastTarget != 0)
        {
            // move toward the last target
            rb.velocity = rb.velocity - Vector2.right * rb.velocity.x + Vector2.right * speed * (lastTarget > 0 ? 1 : -1);

            // flip the sprite
            spriteRenderer.flipX = lastTarget < 0;

            // reduces the last target float
            lastTarget -= (lastTarget > 0 ? 1 : -1) * Time.deltaTime;
            if (Mathf.Abs(lastTarget) < 0.05)
                lastTarget = 0;
        }

        
        // animation
        anim.SetBool("IsMoving", targetDistance != 0 || lastTarget != 0);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (infected == 2)
        {
            if (collision.transform.tag == "Enemy")
            {
                collision.transform.GetComponent<EnemyController>().InfectNow();
            }
            if (collision.transform.tag == "Player")
            {
                collision.transform.GetComponent<InfectionRate>().currentInfection += damage;
            }
        }
    }

    public void InfectNow()
    {
        // become zombie
        GetComponent<ParticleSystem>().Stop();
        infected = 2;
        spriteRenderer.color = Color.green;
        gameObject.layer = 6;
    }

    private void waitInfection()
    {
        if (waitTime > 0)
        {
            waitTime -= Time.deltaTime;
        }
        else
        {
            InfectNow();
        }
    }

    public void InfectEnemy()
    {
        if (infected == 0)
        {
            GetComponent<ParticleSystem>().Play();
            infected = 1;
            Debug.Log("Success");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rb2d;

    //randomly chooses if the ball will go in the left or right directions
    void GoBall()
    {
        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            rb2d.AddForce(new Vector2(20, -15));
        }
        else
        {
            rb2d.AddForce(new Vector2(-20, -15));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //calls GoBall function
        Invoke("GoBall", 2);
    }

    //used when game is won
    void ResetBall()
    {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    //used to reset the game completely
    void RestartGame()
    {
        ResetBall();
        Invoke("GoBall", 1);
    }

    //deals with collision of ball on paddles
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            Vector2 vel;
            vel.x = rb2d.velocity.x;
            vel.y = (rb2d.velocity.y / 2) + (coll.collider.attachedRigidbody.velocity.y / 3);
            rb2d.velocity = vel;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 10;

    private Rigidbody2D rb;

    private void Start()
    {
        Transform player = GameObject.Find("Player").transform;

        rb = GetComponent<Rigidbody2D>();

        if (player.position.x > transform.position.x)
            rb.velocity = new Vector2(speed, rb.velocity.y);
        else
            rb.velocity = new Vector2(-speed, rb.velocity.y);

        if (player.position.y > transform.position.y)
            rb.velocity = new Vector2(rb.velocity.x, speed);
        else
            rb.velocity = new Vector2(rb.velocity.x, -speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            GameManager.instance.InitiateGameOver();
        }
        else
        {
            GameManager.instance.IncreaseScore(10);
        }

        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}

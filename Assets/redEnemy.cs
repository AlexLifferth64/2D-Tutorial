using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redEnemy : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] private float speed = 7f;

    private Transform playerPos;

    private float angle;
    private Vector2 lookDir;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerPos = GameObject.Find("Player").transform;

        transform.position = Vector2.Lerp(transform.position, playerPos.transform.position, 0.01f);

        lookDir = playerPos.position - transform.position;

        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);

        rb.velocity = -transform.up * speed;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.InitiateGameOver();
        }
        else
        {
            GameManager.instance.IncreaseScore(15);
        }

        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}

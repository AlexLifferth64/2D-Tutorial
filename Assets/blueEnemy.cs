using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blueEnemy : MonoBehaviour
{
    private Transform playerPos;

    private float angle;
    private Vector2 lookDir;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.Lerp(transform.position, playerPos.transform.position, 0.01f);

        lookDir = playerPos.position - transform.position;

        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
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

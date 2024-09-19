using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speed = 5;

    [SerializeField] GameObject laser;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
            transform.position = new Vector2(transform.position.x - speed, transform.position.y);
        else if (Input.GetKey(KeyCode.D))
            transform.position = new Vector2(transform.position.x + speed, transform.position.y);
        if (Input.GetKey(KeyCode.W))
            transform.position = new Vector2(transform.position.x, transform.position.y + speed);
        else if (Input.GetKey(KeyCode.S))
            transform.position = new Vector2(transform.position.x, transform.position.y - speed);


        if (Input.GetKeyDown(KeyCode.Space))
            Instantiate(laser, transform.position, transform.rotation);
    }
}

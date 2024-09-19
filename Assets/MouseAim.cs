using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAim : MonoBehaviour
{
    private Camera cam;
    private Transform playerPos;

    private float angle;
    private Vector2 mousePos;
    private Vector2 lookDir;

    void Start()
    {
        playerPos = GetComponent<Transform>();

        cam = GameObject.Find("Camera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        lookDir = mousePos - (Vector2)playerPos.position;

        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }
}

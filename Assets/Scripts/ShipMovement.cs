using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public float moveSpeed = 2.0f;
    public float rotationOffset = 270.0f;

    private Rigidbody2D rb2d;
    private Vector3 mousePos;
    private Vector3 objectPos;
    private Vector2 targetPos;
    private Vector2 shipPosition;
    private float rotateAngle;
    

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Input.mousePosition;
        objectPos = Camera.main.WorldToScreenPoint(transform.position); // position of camera

        mousePos.z = 0;
        mousePos.x = mousePos.x - objectPos.x;
        mousePos.y = mousePos.y - objectPos.y; // adjust relative position of camera to ship

        rotateAngle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, rotateAngle + rotationOffset)); // rotating the ship towards the mouse pointer

        targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition); // gets position of mouse relative to world
        shipPosition = Vector2.MoveTowards(transform.position, targetPos, moveSpeed*Time.deltaTime); // moves towards that point.

    }
    private void FixedUpdate()
    {
        rb2d.MovePosition(shipPosition);
    }

}

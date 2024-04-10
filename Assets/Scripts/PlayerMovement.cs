using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float movSpeed;
    float speedX, speedY;
    Rigidbody2D rb;
    public bool performingAction;
    public static PlayerMovement instance;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(performingAction == false)
        {
        speedX = Input.GetAxisRaw("Horizontal") * movSpeed;
        speedY = Input.GetAxisRaw("Vertical") * movSpeed;
        rb.velocity = new Vector2(speedX, speedY);
        }

    }

    public void StopPerforming()
    {
        performingAction = false;
    }
}

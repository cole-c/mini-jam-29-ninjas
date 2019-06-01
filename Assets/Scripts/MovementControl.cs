using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControl : MonoBehaviour
{
    public float moveSpeed;

    private Vector3 moveInput;
    private Vector3 moveVelocity;
    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0f);

        moveVelocity = moveInput * moveSpeed;
    }

    private void FixedUpdate()
    {
        body.velocity = moveVelocity;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Tooltip("The speed the player moves.")] [SerializeField] float movementSpeed = 5f;
    [Tooltip("The height the player jumps.")] [SerializeField] float jumpHeight = 10f;

    Rigidbody2D myRigidbody2D;
    float raycastLength = 0.6f;
    float offset;

    void Start()
    {
        myRigidbody2D = GetComponent<Rigidbody2D>();
        offset = GetComponent<MeshRenderer>().bounds.size.x / 2f;
    }

    void Update()
    {
        ControlRunning();
        ControlJumping();
    }

    private void ControlRunning() {
        myRigidbody2D.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * movementSpeed, myRigidbody2D.velocity.y);
    }

    private void ControlJumping() {
        float gravity = myRigidbody2D.gravityScale;
        Vector3 vectorOffset = new Vector3(offset, 0f, 0f);
        Vector3 leftRay = transform.position - vectorOffset;
        Vector3 rightRay = transform.position + vectorOffset;

        RaycastHit2D hitLeft = Physics2D.Raycast(leftRay, Vector3.down * gravity, raycastLength, LayerMask.GetMask("Platform", "Gate"));
        RaycastHit2D hitRight = Physics2D.Raycast(rightRay, Vector3.down * gravity, raycastLength, LayerMask.GetMask("Platform", "Gate"));
        if ((hitLeft || hitRight) && Input.GetAxisRaw("Jump") != 0)
        {
            myRigidbody2D.velocity = new Vector2(myRigidbody2D.velocity.x, Input.GetAxisRaw("Jump") * jumpHeight * gravity);
        };
    }
}

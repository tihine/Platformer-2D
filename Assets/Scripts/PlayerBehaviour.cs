using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    [SerializeField] private float jumpForce = 3f;
    private Rigidbody rb;
    [SerializeField] LayerMask floorLayer;
    private void Start()
    {
        Rigidbody2D rb=GetComponent<Rigidbody2D>();

    }
    // Update is called once per frame
    void Update()
    {
        Move();
        if(Input.GetKey(KeyCode.Space))
        {
            Jump();
        }
    }
    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 dimension = new Vector2(horizontalInput,0);
        transform.Translate(dimension*Time.deltaTime*speed);
    }
    private void Jump()
    {
        bool isGrounded = IsGrounded();
        if(isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0f);
            rb.AddForce(Vector2.up * jumpForce, (ForceMode)ForceMode2D.Impulse);
        }
    }

    private bool IsGrounded()
    {
        Debug.DrawRay(transform.position, Vector2.down * 0.6f, Color.green);
        bool isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, floorLayer);
        return isGrounded;
    }
}

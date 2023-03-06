using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;
    private bool isJumping = false;
    private bool isGrounded;
    [SerializeField] LayerMask floorLayer;

    private void Update()
    {
        Debug.DrawRay(transform.position, Vector2.down * 0.6f, Color.green);
        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, floorLayer); 
        float horizontalMovement=Input.GetAxis("Horizontal")*moveSpeed*Time.deltaTime;
        if (Input.GetButtonDown("Jump"))
        {
            isJumping= true;
        }
        MovePlayer(horizontalMovement);
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement,rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, 0.05f); //mouvement pas fluide parfois, à corriger
        if(isJumping==true && isGrounded ==true)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping= false;
        }
    }
}

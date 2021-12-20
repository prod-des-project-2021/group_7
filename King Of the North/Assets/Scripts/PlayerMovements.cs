using UnityEngine;

public class PlayerMovements : MonoBehaviour
{

    public float movingSpeed;
    public float jumpForce;

    public bool isJumping;
    public bool isOnFloor;

    public Transform floorTouching;
    public float floorTouchingRadius;
    public LayerMask CollisionLayers; 

    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private Vector3 velocity = Vector3.zero;

    private float horizontalMovement;

    void Update() 
    {
        horizontalMovement = Input.GetAxis("Horizontal") * movingSpeed * Time.deltaTime;

        // condition for jumping
        if (Input.GetButtonDown("Jump") && isOnFloor)
        {
            isJumping = true;
        }

        Flip(rb.velocity.x);

        float charVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", charVelocity);

    }

    void FixedUpdate()
    {
        isOnFloor = Physics2D.OverlapCircle(floorTouching.position,floorTouchingRadius,CollisionLayers);
        PlayerMove(horizontalMovement);
    }

    void PlayerMove(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);

        if (isJumping == true)
        {
            rb.AddForce(new Vector2(0f, jumpForce));
            isJumping = false;
        }
    }

    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;

        }else if (_velocity < -0.1f)
        {

            spriteRenderer.flipX = true; 
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(floorTouching.position, floorTouchingRadius);
    }

}

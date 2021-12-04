using UnityEngine;

public class PlayerMovements : MonoBehaviour
{

    public float movingSpeed;
    public float jumpForce;

    public bool isJumping;
    public bool isOnFloor;

    public Transform FloorLeft;
    public Transform FloorRight;



    public Rigidbody2D rb;
    private Vector3 velocity = Vector3.zero;

    void FixedUpdate()
    {
        isOnFloor = Physics2D.OverlapArea(FloorLeft.position, FloorRight.position);

        float horizontalMovement = Input.GetAxis("Horizontal") * movingSpeed * Time.deltaTime;

        // condition for jumping
        if (Input.GetButtonDown("Jump") && isOnFloor)
        {
            isJumping = true;
        }


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

}

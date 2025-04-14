using UnityEngine;

public class Player3D : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed = 5f;
    public float jumpSpeed = 10f;
    private bool isOnGround = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputValueHorizontal = Input.GetAxis("Horizontal");
        //float inputValueVertical = Input.GetAxis("Vertical");
        rb.linearVelocity = new Vector2(inputValueHorizontal * moveSpeed, rb.linearVelocity.y);
        if (Input.GetKeyDown(KeyCode.W) && isOnGround)
        {
            Jump();
        }
    }
    private void Jump()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpSpeed);
        isOnGround = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            isOnGround = true;
        }
        if (collision.transform.tag == "Platform")
        {
            transform.SetParent(collision.transform);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Platform")
        {
            transform.SetParent(null);
        }
    }
}

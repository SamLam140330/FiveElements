using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private int speed;
    private float inputX;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 8;
    }

    private void FixedUpdate()
    {
        inputX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(inputX * speed, rb.velocity.y);
    }
}
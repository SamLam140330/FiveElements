using UnityEngine;

public class Player : MonoBehaviour
{
    private float moveSpeed = 2f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Stage1Controller stage1Controller;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stage1Controller = FindObjectOfType<Stage1Controller>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        if(stage1Controller.completeBox < 5)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Box")
        {
            other.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.tag == "Box")
        {
            other.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }
}
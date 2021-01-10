using UnityEngine;

public class Player : MonoBehaviour
{
    public Animator playerAnimator;
    private float moveSpeed;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Stage1Controller stage1Controller;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        stage1Controller = FindObjectOfType<Stage1Controller>();
        moveSpeed = 2f;
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if(Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
        {
            stage1Controller.sfx2.Play();
        }
        else if(!Input.GetButton("Horizontal") && !Input.GetButton("Vertical") && stage1Controller.sfx2.isPlaying)
        {
            stage1Controller.sfx2.Stop();
        }
    }

    private void FixedUpdate()
    {
        if(stage1Controller.completeBox < 5)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
            if(movement.x < 0.0f)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else if(movement.x > 0.0f)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            if(movement.x != 0 || movement.y != 0)
            {
                playerAnimator.SetBool("IsRunning", true);
            }
            else if(movement.x == 0 && movement.y == 0)
            {
                playerAnimator.SetBool("IsRunning", false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Box"))
        {
            other.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Box"))
        {
            other.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }
    }
}
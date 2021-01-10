using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float moveSpeed = 1.5f;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Stage3Controller stage3Controller;
    public Animator playerAnimator;
    public static int currentUI;
    public static int currentQuestion;

    private void Start()
    {
        currentUI = 0;
        currentQuestion = 0;
        rb = GetComponent<Rigidbody2D>();
        stage3Controller = FindObjectOfType<Stage3Controller>();
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
        {
            stage3Controller.sfx3.Play();
        }
        else if (!Input.GetButton("Horizontal") && !Input.GetButton("Vertical") && stage3Controller.sfx3.isPlaying)
        {
            stage3Controller.sfx3.Stop();
        }
    }

    private void FixedUpdate()
    {
        if(currentUI == 0 && currentQuestion == 0 && stage3Controller.checkWon == false)
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
        if(other.gameObject.name == "FireDoor")
        {
            currentUI = 1;
            stage3Controller.DisplayUI();
        }
        else if(other.gameObject.name == "WoodDoor")
        {
            currentUI = 2;
            stage3Controller.DisplayUI();
        }
        else if(other.gameObject.name == "WaterDoor")
        {
            currentUI = 3;
            stage3Controller.DisplayUI();
        }
        else if(other.gameObject.name == "GoldDoor")
        {
            currentUI = 4;
            stage3Controller.DisplayUI();
        }
        else if(other.gameObject.name == "DustDoor")
        {
            currentUI = 5;
            stage3Controller.DisplayUI();
        }
        if(other.gameObject.name == "NPC")
        {
            currentQuestion = 1;
            stage3Controller.ShowQuestion();
        }
        else if(other.gameObject.name == "RealTree")
        {
            currentQuestion = 2;
            stage3Controller.ShowQuestion();
        }
        else if(other.gameObject.name == "CoolDoor")
        {
            currentQuestion = 3;
            stage3Controller.ShowQuestion();
        }
        else if(other.gameObject.name == "Box")
        {
            currentQuestion = 4;
            stage3Controller.ShowQuestion();
        }
        else if(other.gameObject.name == "RealStone")
        {
            currentQuestion = 5;
            stage3Controller.ShowQuestion();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Fire"))
        {
            Destroy(other.gameObject);
            stage3Controller.currentElement = 4;
            stage3Controller.finishedQuestion = "Fire";
            stage3Controller.GetElement();
        }
        if(other.gameObject.CompareTag("Wood"))
        {
            Destroy(other.gameObject);
            stage3Controller.currentElement = 1;
            stage3Controller.finishedQuestion = "Wood";
            stage3Controller.GetElement();
        }
        if(other.gameObject.CompareTag("Water"))
        {
            Destroy(other.gameObject);
            stage3Controller.currentElement = 3;
            stage3Controller.finishedQuestion = "Water";
            stage3Controller.GetElement();
        }
        if(other.gameObject.CompareTag("Gold"))
        {
            Destroy(other.gameObject);
            stage3Controller.currentElement = 0;
            stage3Controller.finishedQuestion = "Gold";
            stage3Controller.GetElement();
        }
        if(other.gameObject.CompareTag("Dust"))
        {
            Destroy(other.gameObject);
            stage3Controller.currentElement = 2;
            stage3Controller.finishedQuestion = "Dust";
            stage3Controller.GetElement();
        }
    }
}
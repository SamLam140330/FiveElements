using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float moveSpeed = 2f;
    private Rigidbody2D rb;
    private Vector2 movement;
    public static int currentUI;
    public static int currentQuestion;
    private Stage3Controller stage3Controller;

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
    }

    private void FixedUpdate()
    {
        if(currentUI == 0 && currentQuestion == 0)
        {//Win Condtion
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
            if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                rb.MovePosition(rb.position + movement * (moveSpeed * 2) * Time.fixedDeltaTime);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name == "FireDoor")
        {
            currentUI = 1;
        }
        else if(other.gameObject.name == "WoodDoor")
        {
            currentUI = 2;
        }
        else if (other.gameObject.name == "WaterDoor")
        {
            currentUI = 3;
        }
        else if (other.gameObject.name == "GoldDoor")
        {
            currentUI = 4;
        }
        else if (other.gameObject.name == "DustDoor")
        {
            currentUI = 5;
        }
        if (other.gameObject.name == "NPC")
        {
            currentQuestion = 1;
        }
        else if (other.gameObject.name == "RealTree")
        {
            currentQuestion = 2;
        }
        else if (other.gameObject.name == "CoolDoor")
        {
            currentQuestion = 3;
        }
        else if (other.gameObject.name == "Box")
        {
            currentQuestion = 4;
        }
        else if (other.gameObject.name == "RealStone")
        {
            currentQuestion = 5;
        }
        if (other.gameObject.name == "Fire")
        {
            Destroy(other.gameObject);
            stage3Controller.finishedQuestion += 1;
            stage3Controller.finishedQuestionImage = 1;
            stage3Controller.GetElement();
            stage3Controller.CheckWin();
        }
        else if (other.gameObject.name == "Wood")
        {
            Destroy(other.gameObject);
            stage3Controller.finishedQuestion += 1;
            stage3Controller.finishedQuestionImage = 2;
            stage3Controller.GetElement();
            stage3Controller.CheckWin();
        }
        else if (other.gameObject.name == "Water")
        {
            Destroy(other.gameObject);
            stage3Controller.finishedQuestion += 1;
            stage3Controller.finishedQuestionImage = 3;
            stage3Controller.GetElement();
            stage3Controller.CheckWin();
        }
        else if (other.gameObject.name == "Gold")
        {
            Destroy(other.gameObject);
            stage3Controller.finishedQuestion += 1;
            stage3Controller.finishedQuestionImage = 4;
            stage3Controller.GetElement();
            stage3Controller.CheckWin();
        }
        else if (other.gameObject.name == "Dust")
        {
            Destroy(other.gameObject);
            stage3Controller.finishedQuestion += 1;
            stage3Controller.finishedQuestionImage = 5;
            stage3Controller.GetElement();
            stage3Controller.CheckWin();
        }
    }
}
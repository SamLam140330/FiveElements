using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private GameObject[] positions = null;
    [SerializeField] private Sprite[] images = null;
    [HideInInspector] public int gotCircle;
    public Animator playerAnimator;
    private float moveSpeed;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Stage2Controller stage2Controller;

    private void Start()
    {
        stage2Controller = FindObjectOfType<Stage2Controller>();
        rb = GetComponent<Rigidbody2D>();
        gotCircle = 0;
        moveSpeed = 6f;
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Horizontal"))
        {
            stage2Controller.sfx2.Play();
        }
        else if (!Input.GetButton("Horizontal") && stage2Controller.sfx2.isPlaying)
        {
            stage2Controller.sfx2.Stop();
        }
    }

    private void FixedUpdate()
    {
        if(stage2Controller.isWon == false)
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
            if(movement.x != 0)
            {
                playerAnimator.SetBool("IsRunning", true);
            }
            else if(movement.x == 0)
            {
                playerAnimator.SetBool("IsRunning", false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Gold"))
        {
            positions[gotCircle].GetComponent<Image>().sprite = images[0];
            Destroy(other.gameObject);
            stage2Controller.sfx1.Play();
            gotCircle += 1;
            stage2Controller.gotElement += "Gold ";
            CheckWin();
        }
        else if(other.gameObject.CompareTag("Wood"))
        {
            positions[gotCircle].GetComponent<Image>().sprite = images[1];
            Destroy(other.gameObject);
            stage2Controller.sfx1.Play();
            gotCircle += 1;
            stage2Controller.gotElement += "Wood ";
            CheckWin();
        }
        else if(other.gameObject.CompareTag("Dust"))
        {
            positions[gotCircle].GetComponent<Image>().sprite = images[2];
            Destroy(other.gameObject);
            stage2Controller.sfx1.Play();
            gotCircle += 1;
            stage2Controller.gotElement += "Dust ";
            CheckWin();
        }
        else if(other.gameObject.CompareTag("Water"))
        {
            positions[gotCircle].GetComponent<Image>().sprite = images[3];
            Destroy(other.gameObject);
            stage2Controller.sfx1.Play();
            gotCircle += 1;
            stage2Controller.gotElement += "Water ";
            CheckWin();
        }
        else if(other.gameObject.CompareTag("Fire"))
        {
            positions[gotCircle].GetComponent<Image>().sprite = images[4];
            Destroy(other.gameObject);
            stage2Controller.sfx1.Play();
            gotCircle += 1;
            stage2Controller.gotElement += "Fire ";
            CheckWin();
        }
    }

    private void CheckWin()
    {
        if(gotCircle == 5)
        {
            stage2Controller.CheckBall();
        }
    }
}
using UnityEngine;

public class Point : MonoBehaviour
{
    private Stage1Controller stage1Controller;

    private void Awake()
    {
        stage1Controller = FindObjectOfType<Stage1Controller>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Box")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            stage1Controller.completeBox += 1;
            stage1Controller.CheckWin();
        }
    }
}
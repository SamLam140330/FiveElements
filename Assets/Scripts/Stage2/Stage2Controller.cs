using System.Collections;
using FiveElement.Opening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace FiveElement.Stage2
{
    public class Stage2Controller : MonoBehaviour
    {
        [SerializeField] private GameObject gameUI = null;
        [SerializeField] private GameObject pauseUI = null;
        [SerializeField] private GameObject tipsUI = null;
        [SerializeField] private GameObject MovingWall = null;
        [SerializeField] private Transform startPoint = null;
        [SerializeField] private Transform endPoint = null;
        [SerializeField] private Text timeTxt = null;
        [SerializeField] private GameObject winTxt = null;
        [SerializeField] private GameObject pauseBtn = null;
        [SerializeField] private new AudioSource audio = null;
        public AudioSource sfx1 = null;
        public AudioSource sfx2 = null;
        [SerializeField] private GameObject[] ball = null;
        [HideInInspector] public string gotElement;
        [HideInInspector] public bool isWon;
        private PlayerMove playerMove;
        private bool isUI;
        private bool gameIsPause;
        private float timeLeft;
        private float moveSpeed;
        private Vector3 currentTarget;

        private void Start()
        {
            playerMove = FindObjectOfType<PlayerMove>();
            Time.timeScale = 0f;
            timeLeft = 60f;
            gameIsPause = false;
            isUI = true;
            isWon = false;
            gameUI.SetActive(true);
            pauseUI.SetActive(false);
            tipsUI.SetActive(true);
            audio.volume = PlayerPrefs.GetFloat("audioVolume", 1f);
            sfx1.volume = PlayerPrefs.GetFloat("sfxVolume", 1f);
            sfx2.volume = PlayerPrefs.GetFloat("sfxVolume", 1f);
            RandomSpawn();
            currentTarget = endPoint.position;
            moveSpeed = 7f;
        }

        private void RandomSpawn()
        {
            for(int i = 0; i < ball.Length; i++)
            {
                Instantiate(ball[i], new Vector2(Random.Range(-8f, 8f), Random.Range(1f, 4f)), Quaternion.identity);
            }
        }

        private void Update()
        {
            CheckESC();
            CheckMovingWall();
            CheckTime();
        }

        private void CheckESC()
        {
            if(isWon == false)
            {
                if(Input.GetKeyDown(KeyCode.Escape))
                {
                    if(isUI == false)
                    {
                        if(gameIsPause == false)
                        {
                            Pause();
                        }
                        else
                        {
                            Resume();
                        }
                    }
                }
            }
        }
    
        private void CheckMovingWall()
        {
            if(isUI == false && gameIsPause == false && isWon == false)
            {
                MovingWall.transform.position = Vector3.MoveTowards(MovingWall.transform.position, currentTarget, moveSpeed * Time.deltaTime);
                if(MovingWall.transform.position == endPoint.position)
                {
                    currentTarget = startPoint.position;
                }
                if(MovingWall.transform.position == startPoint.position)
                {
                    currentTarget = endPoint.position;
                }
            }
        }

        private void CheckTime()
        {
            if(isWon == false)
            {
                timeLeft -= Time.deltaTime;
                timeTxt.text = "剩餘時間: " + (int)timeLeft + "s";
                if(timeLeft <= 30f)
                {
                    timeTxt.color = Color.yellow;
                }
                if(timeLeft <= 15f)
                {
                    timeTxt.color = Color.red;
                }
                if(timeLeft <= 0f)
                {
                    SceneManager.LoadScene("Ending2");
                }
            }
        }

        public void CheckBall()
        {
            if(gotElement == "Gold Wood Dust Water Fire " || gotElement == "Wood Dust Water Fire Gold " || gotElement == "Dust Water Fire Gold Wood " || gotElement == "Water Fire Gold Wood Dust " || gotElement == "Fire Gold Wood Dust Water ")
            {
                sfx2.Stop();
                playerMove.playerAnimator.SetBool("IsRunning", false);



                winTxt.SetActive(true);
                pauseBtn.SetActive(false);
                isWon = true;
                StartCoroutine(NextLevel());
            }
            else
            {
                SceneManager.LoadScene("Ending2");
            }
        }

        IEnumerator NextLevel()
        {
            yield return new WaitForSeconds(5f);
            SceneManager.LoadScene("Stage3");
        }

        public void GotIt()
        {
            isUI = false;
            tipsUI.SetActive(false);
            Time.timeScale = 1f;
        }

        public void Pause()
        {
            gameIsPause = true;
            audio.Pause();
            sfx2.Stop();
            gameUI.SetActive(false);
            pauseUI.SetActive(true);
            Time.timeScale = 0f;
        }

        public void Resume()
        {
            gameIsPause = false;
            audio.Play();
            gameUI.SetActive(true);
            pauseUI.SetActive(false);
            Time.timeScale = 1f;
        }

        public void BackToMenu()
        {
            SceneManager.LoadScene("MainMenu");
        }

        public void Restart()
        {
            SceneManager.LoadScene("Stage2");
        }

        public void QuitGame()
        {
            Application.Quit();
        }
    }
}
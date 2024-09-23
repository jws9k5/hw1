using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using JetBrains.Annotations;
public class PlayerController : MonoBehaviour
{
    float speed;
    
    bool isWin;
    bool isLoss;

    private Rigidbody2D rb2d;


    float timeElapsed;
    float x, y;

    private Vector3 startScale = new Vector3(1.0f, 1.0f, 0);
    private Vector3 powerScale = new Vector3(.5f, .5f, 0);
    private Vector3 powerPos;


    const int minute = 60;
    int seconds = 0;
    int currentTime;
    int endPower = 0;




    public Text timer;
    public Text winText;
    public Text lossText;
    public Button restartButton;
    public GameObject pickUp;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        isWin = false;
        isLoss = false;

        x = UnityEngine.Random.Range(-10.0f, 10.0f);
        y = UnityEngine.Random.Range(-10.0f, 10.0f);

        powerPos = new Vector3(x, y, 0);

        pickUp.transform.position = powerPos;

        rb2d = GetComponent<Rigidbody2D>();
        timeElapsed = 0.0f;

        speed = 10;
        currentTime = 0;
        seconds = 0;


        winText.text = "";
        lossText.text = "";
        SetTimer();

        pickUp.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);



        if ((isLoss == false) && (isWin == false)) 
        {
            timeElapsed += Time.deltaTime;
            seconds = (int)timeElapsed % 60;
            currentTime = minute - seconds;
            timer.text = "Timer: " + currentTime.ToString();

        }

        if (currentTime == 45)
        {
            pickUp.gameObject.SetActive(true);
            

        }

        if (currentTime == endPower)
        {
            speed = 10;

            player.transform.localScale = startScale;

        }

        if ((timeElapsed >= 60.0f) && (isLoss == false)) 
        {
            isWin = true;
            winText.text = "You Win!";
            restartButton.gameObject.SetActive(true);
        }


        rb2d.velocity = movement * speed;
    }


    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Obstacle") && (isWin == false))
        {
            isLoss = true;

            timer.text = "";
            lossText.text = "You Lost!";
            restartButton.gameObject.SetActive(true);
        }

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);

            speed = 20;

            player.transform.localScale = powerScale;

            endPower = currentTime - 10;

        }

    }

    public void OnRestartButtonPress()
    {
        SceneManager.LoadScene("SampleScene");
    }
    void SetTimer()
    {
        timer.text = "Time: " + currentTime.ToString();
    }
}

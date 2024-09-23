using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    float speed;
    
    private Rigidbody2D rb2d;
    float timeElapsed;
    const int minute = 60;
    int seconds;


    public Text timer;
    public Text winText;
    public Button restartButton;
    public Text lossText;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        timeElapsed = 0.0f;

        speed = 10;

        winText.text = "";
        lossText.text = "";
        SetTimer();
        restartButton.gameObject.SetActive(false);
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        rb2d.velocity = movement * speed;
    }





    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            countText.text = "Count: " + count.ToString();

        }
        if (count >= 12)
        {
            winText.text = "You win!";
            restartButton.gameObject.SetActive(true);
        }
    }

    public void OnRestartButtonPress()
    {
        SceneManager.LoadScene("SampleScene");
    }
    void SetTimer()
    {
        timer.text = "Time: " + count.ToString();
    }
}

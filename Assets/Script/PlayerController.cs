using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D Player;
    public GameObject Game_Won_Panel;
    public GameObject Pause_Panel;
    public GameObject Game_Lost_Panel;

    public float speed;
    public bool gameover;
    public bool pause;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameover)
        {
            return;
        }
        if (Input.GetAxis("Cancel") > 0)
        {
            Pause_Panel.SetActive(true);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            Player.velocity = new Vector2(speed, 0);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            Player.velocity = new Vector2(-speed, 0);
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            Player.velocity = new Vector2(0f, speed);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            Player.velocity = new Vector2(0f, -speed);
        }
        else if (Input.GetAxis("Vertical")==0 && Input.GetAxis("Horizontal") == 0)
        {
            Player.velocity = new Vector2(0f, 0f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Door"))
        {
            Debug.Log("Level Completed!");
            Game_Won_Panel.SetActive(true);
            gameover = true;
        }
        if (collision.CompareTag("enemy"))
        {
            Debug.Log("You Lost!");
            Game_Lost_Panel.SetActive(true);
            gameover = true;
        }

        if (collision.CompareTag("item"))
        {
            Debug.Log("item collected!");
        }
           
    }
    public void click_playagain()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("play again");
    }
    public void click_resume()
    {
        Pause_Panel.SetActive(false);
    }


}

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D Player;
    public GameObject Game_Won_Panel;
    public GameObject Pause_Panel;

    public float speed;
    public bool gamewon;
    public bool pause;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gamewon || pause)
        {
            return;
        }
        if (Input.GetAxis("Cancel") > 0)
        {
            Pause_Panel.SetActive(true);
            pause = true;
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
            gamewon = true;
        }
        
        if (collision.CompareTag("item"))
        {
            Debug.Log("item collected!");
        }
           
    }

}

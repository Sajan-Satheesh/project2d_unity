using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D player;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Jump") > 0)
        {
            player.velocity = new Vector2(speed, 0);
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            player.velocity = new Vector2(speed, 0);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            player.velocity = new Vector2(-speed, 0);
        }
        else if (Input.GetAxis("Vertical") > 0)
        {
            player.velocity = new Vector2(0f, speed);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            player.velocity = new Vector2(0f, -speed);
        }
        else //if (Input.GetAxis("Vertical")==0 && Input.GetAxis("Horizontal") == 0)
        {
            player.velocity = new Vector2(0f, 0f);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Door"))
        {
            Debug.Log("Level Completed!");
        }
        
        if (collision.CompareTag("item"))
        {
            Debug.Log("item collected!");
        }
           
    }

}

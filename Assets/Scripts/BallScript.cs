using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float turnSpeed ;
    public float jumpSpeed;
    public Rigidbody2D rb;  //rigidbody obj to control movement since this game object has rb applied to it
   
    public float score;
    AudioSource audioSource;
    public AudioClip scoreAudio;
    public AudioClip gameOverAudio;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    void OnCollisionEnter2D(Collision2D collision) //check for ball collisions with egg obj
    {
        if(collision.gameObject.tag=="GoldenEgg")
        {
           // Debug.Log(test++);
            Destroy(collision.gameObject);
            score++;
            audioSource.PlayOneShot(scoreAudio);
        }

        if (collision.gameObject.tag == "Spikes" )
        {
            audioSource.PlayOneShot(gameOverAudio);
            Destroy(gameObject);  //game over
           
            QuitGame();
        }

        if ( collision.gameObject.tag == "End")
        {
            audioSource.PlayOneShot(gameOverAudio);
            QuitGame();
        }


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(horizontalInput * turnSpeed , rb.velocity.y);
      // rb.velocity = new Vector2(rb.velocity.x, verticalInput * jumpSpeed );
        //transform.Translate(-Vector3.left * horizontalInput * turnSpeed * Time.deltaTime);
        //transform.Translate(-Vector3.down * verticalInput * turnSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }

        if (Input.GetKeyUp(KeyCode.Space) && rb.velocity.y > 0) //check if the space key is released to return down faster
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y / 2) ;
        }

        
    }
}

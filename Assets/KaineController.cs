using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KaineController : MonoBehaviour
{
    KaineController controller;

    // References
    private GameMaster gm;
    
    public bool grounded;

    float speed = 3f;
    Rigidbody2D rb;
    int coins = 0;
    Vector3 startingPosition; // If we hit a spike we will teleport player to starting position.

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Get the rigidbody component added to the object and store it in rb
        startingPosition = transform.position;
        gm = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();

        //For Groundcheck
        controller = GetComponent<KaineController>();
    }

    void Update()
    {
        var input = Input.GetAxis("Horizontal"); // This will give us left and right movement (from -1 to 1). 
        var movement = input * speed;

        rb.velocity = new Vector3(movement, rb.velocity.y, 0);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector3(0, 230, 0)); // Adds 100 force straight up, might need tweaking on that number
        }

        //For Groundcheck
        //if (controller.isGrounded)
        
    }

    // Extra Code for Coins, Bright, Dark, etc, also use GucioDevs follow along to learn

    void OnTriggerEnter2D(Collider2D col) // col is the trigger object we collided with
    {
        if (col.CompareTag("Bright"))
        {
            gm.points += 1;
            Destroy(col.gameObject); // remove the coin
        }
        else if (col.tag == "Water")
        {
            // Death? Reload Scene? Teleport to start:
            transform.position = startingPosition;
        }
        else if (col.tag == "Spike")
        {
            // Death? Reload Scene? Teleport to start:
            transform.position = startingPosition;
        }
        else if (col.tag == "End")
        {
            // Load next level? Heres how you get this level's scene number, add 1 to it and load that scene:
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    // Extra Code for Coins, Bright, Dark, etc
    
        if (col.tag == "Bright, Dark")
        {
            coins++;
            Destroy(col.gameObject);
        }
        else if (col.tag == "Water")
        {
            transform.position = startingPosition;
        }
        else if (col.tag == "Spike")
        {
            // Death? Reload Scene? Teleport to start:
            transform.position = startingPosition;
        }

        // scenemanagement went to scene manager because it sensed error
        else if (col.tag == "End")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        /*
        *
        * Keep adding objects to collide with here!
        *
        */
    }
}

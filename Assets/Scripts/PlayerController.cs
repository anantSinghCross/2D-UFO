using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    // what we have to do is check for inputs at every frame and then apply them to the Player object
    // we therfore have two options 'FixedUpdate()' and 'Update()'

    // Update() is called before rendering every frame and FixedUpdate() is called just before any
    // physics calculations. Physics code goes in this function

    // to change a component we need to add a reference to that component
    public float speed;
    private int count;
    private int targetScore;

    private Rigidbody2D rb2d;
    public Text points;
    public Text winText;

    // Start() gets called once in a life time of the game. Used to initialise variables
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        targetScore = 4;
        winText.text = "";
        SetPointsText();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // we'll make a Vector2() obj that will hold the above two variables and pass it on to AddForce()
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }

    // if our Player model collides with the models tagged 'Pickup'
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetPointsText();
        }
    }

    void SetPointsText()
    {
        points.text = "Points: " + count.ToString();
        if(count>= targetScore)
        {
            winText.text = "You Win";
        }
    }
}

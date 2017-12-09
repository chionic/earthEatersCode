using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class earth : MonoBehaviour {
    public static int eatEarth = 0; //how much health the earth has left - when it reaches 0 it's game over
    public static int foodLeft; //how much of a resource is left in the mouse pointer
    public static earth instance = null; //singleton instance accessor

    public Text percentage; //on screen text
    public Text scoreText; //on screen text
    public int earthHealth = 100; //how much health the planet has left
    private float score = 0;
    private SpriteRenderer earthSprite; //for changing what the earth looks like
    public Sprite[] earths; //array of earth sprites to change what the earth looks like
    public Text gameOver; //on screen text
    public GameObject next; // on screen button

    //create a singleton pattern for the tiles function, makes it easy to call from anywhere
    void Awake()
    {
        //Check if instance already exists
        if (instance == null)
            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)
            //Then destroy this
            Destroy(gameObject);
    }

    // Use this for initialization
    void Start()
    {
        earthSprite = this.GetComponent<SpriteRenderer>();
        next.SetActive(false); //make the next button inactive
    }

    //change the score 
    public void changeScore(float toAdd)
    {
        score += toAdd;
    }

    //change the health of the planet
    public void healthChange(int amount)
    {
        earthHealth -= amount; //take away the amount of health specified
        percentage.text = earthHealth + "%"; //print the remaining health on screen
        //if the health of the earth reaches 0, end the game
        if (earthHealth <= 0)
        {
            soundManager.instance.PlayEffect(4);
            earthSprite.sprite = earths[3];
            gameOver.text = "Game Over   You're Score: " + score;
            percentage.text = "";
            scoreText.text = "";
            next.SetActive(true);
            
        }
        //change the planet sprite depending on how much health the earth has left
        else if (earthHealth <= 20)
        {
            earthSprite.sprite = earths[2];
        }
        else if(earthHealth<= 50)
        {
            earthSprite.sprite = earths[1];
        }
        else if(earthHealth <= 80)
        {
            earthSprite.sprite = earths[0];
        }

    }

    // Update is called once per frame
    void Update()
    {
        //add to the player score depending on how long they have survived
        score += 0.01f;
        if (earthHealth > 0)
        {
            scoreText.text = "Score " + (int)score;
        }
        //if the player has no resources left in the mouse pointer, change the colour of the mouse pointer to white
        if (earth.foodLeft < 1)
        {
            colorTile.changeColour(Color.white);
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class earth : MonoBehaviour {
    public static int eatEarth =0;
    public static int foodLeft;
    public static earth instance = null;
    public Text percentage;
    public Text scoreText;
    public int earthHealth = 100;
    private float score = 0;
    private SpriteRenderer earthSprite;
    public Sprite[] earths;
    public Text gameOver;
    public GameObject next;

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
    void Start()
    {
        earthSprite = this.GetComponent<SpriteRenderer>();
        next.SetActive(false);
    }
    public void changeScore(float toAdd)
    {
        score += toAdd;
    }
    public void healthChange(int amount)
    {
        earthHealth -= amount;
        percentage.text = earthHealth + "%";
        if (earthHealth <= 0)
        {
            soundManager.instance.PlayEffect(4);
            earthSprite.sprite = earths[3];
            gameOver.text = "Game Over   You're Score: " + score;
            percentage.text = "";
            scoreText.text = "";
            next.SetActive(true);
            
        }
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
        score += 0.01f;
        if (earthHealth > 0)
        {
            scoreText.text = "Score " + (int)score;
        }
        if (earth.foodLeft < 1)
        {
            colorTile.changeColour(Color.white);
        }

    }
}


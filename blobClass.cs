using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blobClass : MonoBehaviour
{
    float size = 10; //size of the blob to begin with
    float fed = 5; //how many times you have fed the blob, changes how much health taken off planet
    int rocket = 20; //how big the blob needs to be to blast off
    int earthEater = 0; //how small the blob needs to be to become a earth eater
    float shrinker = 3; //the number of seconds before the blob shrinks (size gets smaller)
    float sizeChanger = 2f;
    private Color colourWant = Color.red; //the colour needed to feed the blo
    private SpriteRenderer want; //the dot over blobs head reference
    public Animator animator;
    public int angle; //store where our blob spawned, so no other blobs can spawn there until its dead/blasted off
    private float soundFin = 0; //timer to stop the eating sound endlessly replaying

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        want = this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
        objectPoolReset();
    }

    // Update is called once per frame
    void Update()
    {
        //makes the blob disappear when the game is over
        if(earth.instance.earthHealth <= 0)
        {
            this.gameObject.SetActive(false);
        }
        //makes the blob smaller as time passes in game
        if (shrinker < Time.time)
        {
            size--;
            if (size <= earth.eatEarth)
            {
                earth.instance.healthChange((int)fed); //take away the health percenage from earth
                soundManager.instance.PlayEffect(3);
                objectPoolReset(); //get this object ready for reactivation
                gameObject.SetActive(false); //set this gameobect inactive
                blobPool.instance.addBlob(gameObject); //add gameobject to pool
                blobPool.instance.posPositions.Add(angle); //add the position the blob was at back to the pool of possible positions
            }
            //changes the rate over time at which blobs grow smaller
            if (Time.time > 210)
            {
                shrinker = Time.time + 2;
            }
            else if (Time.time > 180)
            {
                shrinker = Time.time + 3;
            }
            else if (Time.time > 90)
            {
                shrinker = Time.time + 4;
            }
            shrinker = Time.time + 5;
        }
        //makes the blob 'blast off', removing it without causing damage to the earth
        if (size >= rocket)
        {
            soundManager.instance.PlayEffect(6);
            earth.instance.changeScore(fed); //give player points for letting the blob blast off
            objectPoolReset(); //get blob ready for reactivation
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false); //deactivate the colour icon above the blobs head
            blobPool.instance.addBlob(gameObject); //add game object to pool
            blobPool.instance.posPositions.Add(angle);
            this.gameObject.SetActive(false);
        }
    }

    //lets us know when the blob is hovered over
    void OnMouseOver()
    {
        //if the mouse pointer is the right colour, feeds the blob
        if (colourWant == colorTile.getColour() && earth.foodLeft > 0)
        {
            earth.foodLeft -= 1;
            size += sizeChanger;
            fed = fed + 0.2f;
        }
    }

    //gets our object ready to start again as part of the object pool
    void objectPoolReset()
    {
        //keep things interesting by changing the starting size and size needed to go away harmlessly
        size = earth.eatEarth + 5;
        rocket = earth.eatEarth + 15;
        shrinker = Time.time + 3;
        fed = 10;
        colourWant = colorTile.colours[Random.Range(0, 3)];
        want.color = colourWant;
    }
}

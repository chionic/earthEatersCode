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
    private Color colourWant = Color.red;
    private SpriteRenderer want;
    public Animator animator;
    public int angle;
    private float soundFin = 0;


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
        if(earth.instance.earthHealth <= 0)
        {
            this.gameObject.SetActive(false);
        }
        if (shrinker < Time.time)
        {
            size--;
            if (size <= earth.eatEarth)
            {
                earth.instance.healthChange((int)fed);
                //do all the cool eating earth animation and sound stuff
                soundManager.instance.PlayEffect(3);
                objectPoolReset();
                gameObject.SetActive(false);
                blobPool.instance.addBlob(gameObject); //add gameobject to pool
                blobPool.instance.posPositions.Add(angle);
                Debug.Log("eat earth");
            }
            if (Time.time > 210)
            {
                shrinker = Time.time + 1;
            }
            else if (Time.time > 180)
            {
                shrinker = Time.time + 2;
            }
            else if (Time.time > 90)
            {
                shrinker = Time.time + 3;
            }
            shrinker = Time.time + 5;
        }
        if (size >= rocket)
        {
            //do all the cool rocket blasting into space animation and sound stuff
            earth.instance.changeScore(fed);
            objectPoolReset();
            this.gameObject.transform.GetChild(0).gameObject.SetActive(false);
            blobPool.instance.addBlob(gameObject); //add game object to pool
            blobPool.instance.posPositions.Add(angle);
            this.gameObject.SetActive(false);
            //animator.SetTrigger("blastOff");
        }
    }
    //lets us know when the blob is hovered over
    void OnMouseOver()
    {
        if (colourWant == colorTile.getColour() && earth.foodLeft > 0)
        {
            if (soundFin < Time.time)
            {
                soundManager.instance.PlayEffect(Random.Range(5,7));
                soundFin = Time.time + 1;
            }
            earth.foodLeft -= 1;
            size += sizeChanger;
            fed = fed + 0.2f;
        }


    }
 
   

    //gets our object ready to start again as part of the object pool
    void objectPoolReset()
    {
        //keep things interesting by changing the starting size and size needed to go away harmlessly
        size = Random.Range(earth.eatEarth + 5, earth.eatEarth + 10);
        rocket = Random.Range(earth.eatEarth + 25, earth.eatEarth + 30);
        shrinker = Time.time + 3;
        fed = 10;
        colourWant = colorTile.colours[Random.Range(0, 3)];
        want.color = colourWant;
    }

}

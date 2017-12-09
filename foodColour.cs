using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodColour : MonoBehaviour {
    //attached to planet, used to change resource to give blobs
    public Color colour; //the colour of the planet in question
    private float size = 100; //its starting size
    private float sizeLoss = 2f; //how much smaller it gets when the mouse hovers over it
    private float useCounter = 0; //how many times the planet has een used
    private float soundFin = 0; //timer until the taking resourcs planet soud is played again

    //when mouse hovers over the planet, reset the amount of resources left in the mouse pointer
    void OnMouseEnter()
    {
        earth.foodLeft = 0;
    }

    //when the mouse hovers over the planet
    void OnMouseOver()
    {   
        colorTile.changeColour(colour); //change the mouse pointer colour to the planet colour
        earth.foodLeft += 3; //add more resources the player has in the mouse pointer
        size -= sizeLoss; //make the planet smaller
        if (soundFin < Time.time) //play the taking resources from planet soud effect when timer runs out
        {
            soundManager.instance.PlayEffect(0);
            soundFin = Time.time + 1;
        }
        useCounter++; //add 1 to how many times we've used this planet for resources
        if (useCounter > 500) //increases the rate at which the planet loses its size as the game progresses
        {
            sizeLoss += 1;
        }
        //if the planet is too small (all the resources have been used up), make it disappear
        if(size <= 10)
        {
            gameObject.SetActive(false);
        }
    }

    //called once per frame
    private void Update()
    {
        //makes our planet grow when left alone by the mouse pointer
        if (size < 100)
        {
            size += 0.1f*(1/sizeLoss);
        }
        gameObject.transform.localScale = new Vector3(size/10, size/10,0);
        
    }
}

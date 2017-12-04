using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class foodColour : MonoBehaviour {
    //attached to planet, used to change resource to give blobs
    public Color colour;
    private float size = 100;
    private float sizeLoss = 2f;
    private float useCounter = 0;
    private float soundFin = 0;

    void OnMouseEnter()
    {
        earth.foodLeft = 0;
    }
    void OnMouseOver()
    {   
        colorTile.changeColour(colour);
        earth.foodLeft += 3;
        size -= sizeLoss;
        if (soundFin < Time.time)
        {
            soundManager.instance.PlayEffect(0);
            soundFin = Time.time + 1;
        }
        useCounter++;
        if (useCounter > 500)
        {
            sizeLoss += 1;
        }
        if(size <= 10)
        {
            gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (size < 100)
        {
            size += 0.1f*(1/sizeLoss);
        }
        gameObject.transform.localScale = new Vector3(size/10, size/10,0);
        
    }
}

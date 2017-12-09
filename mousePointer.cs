using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousePointer : MonoBehaviour {
    SpriteRenderer sr; //the new mouse pointer sprite

	// Use this for initialization
	void Start () {
        sr = this.gameObject.GetComponent<SpriteRenderer>();
        Cursor.visible = false; //makes default cursor invisible
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 mousePosition = Input.mousePosition;//gets the position of the mousr on screen
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition); //puts the position in terms of on screen coordinates (center 0,0)
        this.transform.position = new Vector3(mousePosition.x,mousePosition.y,-2); //places our custom pointer sprite where mouse would be
	}

    //changes the colour of the mouse pointer
    public void changeMouseColour(Color colour)
    {
        sr.color = colour;
    }
}

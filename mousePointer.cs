using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousePointer : MonoBehaviour {
    SpriteRenderer sr;

	// Use this for initialization
	void Start () {
        sr = this.gameObject.GetComponent<SpriteRenderer>();
        Cursor.visible = false;
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        this.transform.position = new Vector3(mousePosition.x,mousePosition.y,-2);   
	}

    public void changeMouseColour(Color colour)
    {
        sr.color = colour;
    }
}

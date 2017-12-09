using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorTile : MonoBehaviour {
    //change the colour of the mouse pointer
    private static mousePointer mp; //the mouse pointer game object
    public static Color currColour = Color.red; //current colour of the mouse pointer
    public static Color[] colours = new Color[] { Color.red, Color.green, new Color32(0,175,255,255)}; //possible mouse pointer colours

    //change the colour of the mouse pointer
    public static void changeColour(Color color)
    {
        mp = GameObject.FindGameObjectWithTag("mp").GetComponent<mousePointer>();
        currColour = color;
        mp.changeMouseColour(color);
    }

    //get the current colour of the mouse pointer
    public static Color getColour()
    {
        return currColour;
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorTile : MonoBehaviour {
    private static mousePointer mp;
    public static Color currColour = Color.red;
    public static Color[] colours = new Color[] { Color.red, Color.green, new Color32(0,175,255,255) };

    public static void changeColour(Color color)
    {
        mp = GameObject.FindGameObjectWithTag("mp").GetComponent<mousePointer>();
        currColour = color;
        mp.changeMouseColour(color);
    }

    public static Color getColour()
    {
        return currColour;
    }


}

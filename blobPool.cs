using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blobPool : MonoBehaviour {
    public static blobPool instance = null; //singleton pattern instance
    public List<GameObject> blobs; //a game object pool for the blobs
    public List<int> posPositions = new List<int>(); //possible positions the blobs can have on the earth

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
    void Start () {
        //creates a list of possible positions our blobs can spawn at (in terms of degrees around a circle)
        for (int i = 0; i < 360; i += 10) 
        {
            posPositions.Add(i);
        }
    }

    //adds a blob to blob pool
    public void addBlob (GameObject blob)
    {
        blobs.Add(blob);
    }

    //gets a blob from blob pool
    public GameObject getBlob()
    {
        if (blobs.Count > 0)
        {
            return blobs[0];
        }
        else
        {
            Debug.Log("no blobs found");
            return null;
        }
    }

    //removes a blob from blob pool
    public void removeBlob()
    {
        if (blobs.Count > 0)
        {
            blobs.RemoveAt(0);
        }
        
    }

    //prints how many blobs are currently in blob pool
    void inactiveBlobs()
    {
        Debug.Log("inactive blobs: " + blobs.Count);
    }

    
}

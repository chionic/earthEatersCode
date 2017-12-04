using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blobPool : MonoBehaviour {
    public static blobPool instance = null;
    public List<GameObject> blobs;
    public List<int> posPositions = new List<int>();

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
        for (int i = 0; i < 360; i += 10)
        {
            posPositions.Add(i);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void addBlob (GameObject blob)
    {
        blobs.Add(blob);
    }
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
    public void removeBlob()
    {
        if (blobs.Count > 0)
        {
            blobs.RemoveAt(0);
        }
        
    }
    void inactiveBlobs()
    {
        Debug.Log("inactive blobs: " + blobs.Count);
    }

    
}

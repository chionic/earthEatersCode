using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blobSpawner : MonoBehaviour {
    //script use to 'spawn' new blobs through out the game, increases in speed the longer you play
    private float nextSpawn = 5;
    private float countDown = 2;

	// Use this for initialization
	void Start () {
        nextSpawn = Time.time + 1;
        
	}
	
	// Update is called once per frame
	void Update () {
        if (nextSpawn < Time.time)
        {
            //gets a blob from the blob pool (a list of blobs in the blob pool script)
            GameObject newBlob = blobPool.instance.getBlob();
            if (newBlob != null) //if our blob pool returned a blob (ie, it is not empty)
            {
                //pick a random position from the list for the blob to spawn
                int index = Random.Range(0, blobPool.instance.posPositions.Count-2); 
                int angle = blobPool.instance.posPositions[index]; 
                blobPool.instance.posPositions.RemoveAt(index); //remove it from the list of possible positions
                float x = (Mathf.Cos(angle * Mathf.Deg2Rad))*3.5f; //get the x coordinate for this position
                float y = (Mathf.Sin(angle * Mathf.Deg2Rad))*3.5f; //get the y coordinate for this position
                blobPool.instance.removeBlob(); //remove he blob we got from the blob pool
                newBlob.transform.position = new Vector3(x, y, 0); //put the blobs transform at the position we got
                newBlob.transform.rotation = Quaternion.Euler(0, 0, angle - 90); //rotate it so that its always pointing away from circle center
                newBlob.GetComponent<blobClass>().angle = angle; //save the angle of this blobs position in the blob class for later
                newBlob.transform.GetChild(0).gameObject.SetActive(true); //let the player see the dot above the blobs head
                newBlob.SetActive(true); //activate the blob
            }
            //changes how long it takes for the next blob to spawn
            if (countDown > 0.8)
            {
                countDown = countDown - 0.05f;
            }
            else if(countDown > 0.1)
            {
                countDown = countDown - 0.01f;
            }
            nextSpawn = Time.time + countDown;
        }
	}
}

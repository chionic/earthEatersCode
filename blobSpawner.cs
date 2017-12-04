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
            GameObject newBlob = blobPool.instance.getBlob();
            if (newBlob != null)
            {
                int index = Random.Range(0, blobPool.instance.posPositions.Count-2);
                int angle = blobPool.instance.posPositions[index];
                blobPool.instance.posPositions.RemoveAt(index);
                float x = (Mathf.Cos(angle * Mathf.Deg2Rad))*3.5f;
                float y = (Mathf.Sin(angle * Mathf.Deg2Rad))*3.5f;
                blobPool.instance.removeBlob();
                newBlob.transform.position = new Vector3(x, y, 0);
                newBlob.transform.rotation = Quaternion.Euler(0, 0, angle - 90);
                newBlob.GetComponent<blobClass>().angle = angle;
                newBlob.transform.GetChild(0).gameObject.SetActive(true);
                newBlob.SetActive(true);
            }
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

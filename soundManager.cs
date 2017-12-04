using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour {

    public static AudioSource sfxSource; //source to play music from (when I get to it)
    public static soundManager instance = null; //singleton pattern
    public GameObject[] sounds; //array of sound effects

    // Sound manager singleton pattern
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

        //Sets this to not be destroyed when reloading scene
        DontDestroyOnLoad(gameObject);
    }

    //plays a sound effect at the specified array index
    public void PlayEffect(int x)
    {
        sounds[x].GetComponent<AudioSource>().Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenuButtons : MonoBehaviour {
    //script to control what the buttons in game do
    public GameObject panel = null; //tutorial panel object

    //exit the game
	public void exitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    //start the main game (not menu)
    public void startGame(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    //make the tutorial panel active
    public void tutorial()
    {
        panel.SetActive(true);
    }

    //set the tutorial panel inactive
    public void back()
    {
        panel.SetActive(false);
    }

    //load the gameover scene
    public void next()
    {
        SceneManager.LoadScene(2);
        Cursor.visible =true;
    }


}

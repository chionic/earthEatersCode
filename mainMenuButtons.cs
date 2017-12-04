using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenuButtons : MonoBehaviour {
    public GameObject panel = null;
	public void exitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void startGame(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void tutorial()
    {
        panel.SetActive(true);
    }

    public void back()
    {
        panel.SetActive(false);
    }

    public void next()
    {
        SceneManager.LoadScene(2);
        Cursor.visible =true;
    }


}

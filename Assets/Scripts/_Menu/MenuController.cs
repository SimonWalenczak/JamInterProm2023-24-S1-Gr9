using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject MenuPanel;
    public void Play()
    {
        MenuPanel.SetActive(false);
        Cursor.visible = false;
        GameManager.instance.canBug = true;

        foreach (var gameSound in GameManager.instance.GameSounds)
        {
            gameSound.GetComponent<AudioSource>().Play();
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    
    public void Quit()
    {
        //If we are running in a standalone build of the game
#if UNITY_STANDALONE
        //Quit the application
        Application.Quit();
#endif

        //If we are running in the editor
#if UNITY_EDITOR
        //Stop playing the scene
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}

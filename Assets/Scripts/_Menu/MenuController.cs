using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject MenuPanel;

    public List<GameObject> InteractibleScreens;
    public Image BlackGround;
    public Image ScreenOff;
    public GameObject StartScreen;
    
    [Header("ScreenGoDown")]
    public float ScreenGoDownSpeed;
    public float TimeBeforeBlackGround;
    
    [Header("BlackGround")]
    public float BlackGroundFadeSpeed;
    public float TimeBeforeScreenOff;

    [Header("ScreenOff")]
    public float ScreenOffFadeInSpeed;
    public float ScreenOffFadeOutSpeed;
    public float TimeBeforePlay;

    
    public void Play()
    {
        StartCoroutine(GoToPlayMode());
    }

    public IEnumerator GoToPlayMode()
    {
        foreach (var screen in InteractibleScreens)
        {
            screen.transform.DOMoveY(transform.position.y - 10, ScreenGoDownSpeed);
        }
        yield return new WaitForSeconds(TimeBeforeBlackGround);
        
        BlackGround.DOFade(0, BlackGroundFadeSpeed);
        yield return new WaitForSeconds(TimeBeforeScreenOff);

        ScreenOff.DOFade(1, ScreenOffFadeInSpeed);
        yield return new WaitForSeconds(ScreenOffFadeInSpeed);
        StartScreen.SetActive(false);

        ScreenOff.DOFade(1, ScreenOffFadeOutSpeed);
        yield return new WaitForSeconds(TimeBeforePlay);

        MenuPanel.SetActive(false);

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

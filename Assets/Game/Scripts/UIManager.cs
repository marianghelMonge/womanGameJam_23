using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video; 

public class UIManager : SingletonPattern<UIManager>
{
    public GameObject introScreen;
    public GameObject gameOverScreen;
    public GameObject creditsScreen;
    public GameObject gameUI;
    public VideoPlayer introVideoPlayer;
    public VideoPlayer creditsVideoPlayer;

    // Start is called before the first frame update
    void Start()
    {
        introVideoPlayer.loopPointReached += HideIntro;
        creditsVideoPlayer.loopPointReached += HideCredits;
    }

    public void ShowIntro()
    {
        introScreen.SetActive(true);
        gameOverScreen.SetActive(false);
        creditsScreen.SetActive(false);
        gameUI.SetActive(false);
        introVideoPlayer.Play();
    }

    public void ShowGameOver()
    {
        introScreen.SetActive(false);
        gameOverScreen.SetActive(true);
        creditsScreen.SetActive(false);
        gameUI.SetActive(false);
        
    }

    public void ShowCredits()
    {
        introScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        creditsScreen.SetActive(true);
        gameUI.SetActive(false);
        creditsVideoPlayer.Play();
    }

    public void ShowGameUI()
    {
        introScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        creditsScreen.SetActive(false);
        gameUI.SetActive(true);
        
    }

    private void HideIntro(VideoPlayer source)
    {
        ShowGameUI();
    }

    private void HideCredits(VideoPlayer source)
    {
        ShowGameOver();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}

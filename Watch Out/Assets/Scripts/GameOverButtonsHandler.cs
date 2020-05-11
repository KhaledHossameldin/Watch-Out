using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverButtonsHandler : MonoBehaviour
{
    GameHandler gameHandler;
    GameSceneHandler gameSceneHandler;

    private void Start()
    {
        gameHandler = FindObjectOfType<GameHandler>();
        gameSceneHandler = FindObjectOfType<GameSceneHandler>();
    }

    public void RestartGame()
    {
        gameHandler.ResetGame();
        gameSceneHandler.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

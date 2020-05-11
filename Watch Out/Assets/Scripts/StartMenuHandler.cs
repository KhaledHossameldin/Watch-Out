using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuHandler : MonoBehaviour
{
    [SerializeField] Canvas mainCanvas;
    [SerializeField] Canvas storyCanvas;

    private void Start()
    {
        storyCanvas.enabled = false;
    }

    public void ShowStory()
    {
        if (mainCanvas.enabled)
        {
            mainCanvas.enabled = false;
        }
        else
        {
            mainCanvas.enabled = true;
        }

        if (storyCanvas.enabled)
        {
            storyCanvas.enabled = false;
        }
        else
        {
            storyCanvas.enabled = true;
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

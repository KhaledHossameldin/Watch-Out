using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGameHandler : MonoBehaviour
{
	[SerializeField] Canvas pauseCanvas;

	private void Start()
	{
		pauseCanvas.enabled = false;
	}

	public void Pause()
	{
		Time.timeScale = 0;
		pauseCanvas.enabled = true;
	}

	public void Resume()
	{
		Time.timeScale = 1;
		pauseCanvas.enabled = false;
	}

	public void QuitGame()
	{
		Application.Quit();
	}
}

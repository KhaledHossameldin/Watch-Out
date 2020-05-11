using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoBack : MonoBehaviour
{
	public void GoBackPress()
	{
		FindObjectOfType<GameSceneHandler>().LoadScene(0);
	}
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighscoreHandler : MonoBehaviour
{
    void Start()
    {
        int currentScore = FindObjectOfType<GameHandler>().GetScore();
        int highscore = PlayerPrefs.GetInt("Highscore", 0);
        if (currentScore > highscore)
        {
            PlayerPrefs.SetInt("Highscore", currentScore);
            GetComponent<TextMeshProUGUI>().color = new Color(0, 1, 0.5f);
            GetComponent<TextMeshProUGUI>().text = "New Highscore: " + currentScore;
        }
        else
        {
            GetComponent<TextMeshProUGUI>().text = "Highscore: " + highscore;
        }
    }
}

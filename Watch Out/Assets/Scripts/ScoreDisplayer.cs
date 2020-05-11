using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplayer : MonoBehaviour
{
    GameHandler gameHandler;
    TextMeshProUGUI scoreText;

    void Start()
    {
        gameHandler = FindObjectOfType<GameHandler>();
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        scoreText.text = gameHandler.GetScore().ToString();
    }
}

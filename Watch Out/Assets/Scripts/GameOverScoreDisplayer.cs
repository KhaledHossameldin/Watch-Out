using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverScoreDisplayer : MonoBehaviour
{
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = FindObjectOfType<GameHandler>().GetScore().ToString();
    }
}

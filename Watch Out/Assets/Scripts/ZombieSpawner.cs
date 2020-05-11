using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] GameObject zombie;
    SoundHandler soundHandler;
    GameHandler gameHandler;
    float waitTime;

    private void Awake()
    {
        soundHandler = FindObjectOfType<SoundHandler>();
        gameHandler = FindObjectOfType<GameHandler>();
        waitTime = 2;
    }

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            
            Instantiate(zombie, CalculateZombiePosition(), Quaternion.identity);
            soundHandler.PlayZombieSpawnSound(transform.position);

            SetWaitTime();
        }
    }

    private void SetWaitTime()
    {
        if (waitTime > 1)
        {
            int currentScore = gameHandler.GetScore();
            if (currentScore <= 20)
            {
                waitTime = 2;
            }
            if (currentScore > 20 && currentScore <= 35)
            {
                waitTime = 1.75f;
            }
            else if (currentScore > 35 && currentScore <= 50)
            {
                waitTime = 1.5f;
            }
            else if (currentScore > 50 && currentScore <= 65)
            {
                waitTime = 1.25f;
            }
            else if (currentScore > 50)
            {
                waitTime = 1;
            }
        }
    }

    private Vector2 CalculateZombiePosition()
    {
        while (true)
        {
            Vector2 zombiePosition = new Vector2(Random.Range(-4.3f, 4.3f), Random.Range(-1.9f, 1.9f));
            float cameraSize = Camera.main.orthographicSize;
            Vector2 cameraPosition = Camera.main.transform.position;
            if ((zombiePosition.x < cameraPosition.x - cameraSize * 16 / 9 || zombiePosition.x > cameraPosition.x + cameraSize * 16 / 9) 
                && (zombiePosition.y < cameraPosition.y - cameraSize || zombiePosition.y > cameraPosition.y + cameraSize))
            {
                return zombiePosition;
            }
        }
    }
}

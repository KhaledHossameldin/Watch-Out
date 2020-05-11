using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ZombieHandler : MonoBehaviour
{
    [SerializeField] GameObject zombieDeathVFX;
    MainCharacterHandler mainCharacter;
    GameHandler gameHandler;
    float moveSpeed;
    int health;

    void Start()
    {
        mainCharacter = FindObjectOfType<MainCharacterHandler>();
        gameHandler = FindObjectOfType<GameHandler>();
        SetHealth();
        moveSpeed = 0.5f;
    }

    void Update()
    {
        if (mainCharacter.GetComponent<SpriteRenderer>().sprite != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, mainCharacter.transform.position, moveSpeed * Time.deltaTime);

            Vector3 offset = mainCharacter.transform.position - transform.position;
            transform.rotation = Quaternion.LookRotation(Vector3.forward, offset); 
        }
    }

    private void SetHealth()
    {
        int currentScore = gameHandler.GetScore();
        if (currentScore <= 20)
        {
            health = 70;
        }
        else if (currentScore > 20 && currentScore <= 40)
        {
            health = 80;
        }
        else if (currentScore > 40 && currentScore <= 60)
        {
            health = 90;
        }
        else if (currentScore > 60)
        {
            health = 100;
        }
    }

    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            Destroy(gameObject);
            gameHandler.AddToScore(5);
            GameObject zombieDeathVFXCopy = Instantiate(zombieDeathVFX, transform.position, Quaternion.identity);
            Destroy(zombieDeathVFXCopy, 11);
        }
    }
}

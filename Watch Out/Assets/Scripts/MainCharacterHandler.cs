using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MainCharacterHandler : MonoBehaviour
{
    [SerializeField] GameObject mainCharacterDeathVFX;
    HealtBarHandler healthBar;
    int health;
    float nextTimeToDamage = 0;
    float moveSpeed;
    float damageRate;

    private void Start()
    {
        healthBar = FindObjectOfType<HealtBarHandler>();
        health = 100;
        moveSpeed = 1;
        damageRate = 5;
    }

    void Update()
    {
        Move();

        LookToMouse();
    }

    private void TakeDamage(int damageAmount)
    {
        health -= damageAmount;
        healthBar.SetHealth(health);
        if (health <= 0)
        {
            GetComponent<SpriteRenderer>().sprite = null;
            GameObject mainCharacterDeathVFXCopy = Instantiate(mainCharacterDeathVFX, transform.position, Quaternion.identity);
            Destroy(mainCharacterDeathVFXCopy, 11);
            StartCoroutine(Die());
        }
    }

    public void AddHealth(int healthAmount)
    {
        if (health + healthAmount < 100)
        {
            health += healthAmount;
        }
        else
        {
            health = 100;
        }
        healthBar.SetHealth(health);
    }

    private void LookToMouse()
    {
        Vector2 mousePosition = Input.mousePosition;

        Vector2 mainCharacterPosition = Camera.main.WorldToScreenPoint(transform.position);
        mousePosition -= mainCharacterPosition;

        float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    private void Move()
    {
        if (GetComponent<SpriteRenderer>().sprite != null)
        {
            float xTranslation = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
            float yTranslation = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

            if (xTranslation > 0)
            {
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            }
            if (xTranslation < 0)
            {
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            }
            if (yTranslation > 0)
            {
                transform.position += Vector3.up * moveSpeed * Time.deltaTime;
            }
            if (yTranslation < 0)
            {
                transform.position += Vector3.down * moveSpeed * Time.deltaTime;
            } 
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Zombie") && Time.time >= nextTimeToDamage && GetComponent<SpriteRenderer>().sprite != null)
        {
            TakeDamage(5);
            FindObjectOfType<SoundHandler>().PlayZombieBite(collision.transform.position);
            nextTimeToDamage = Time.time + (1 / damageRate);
        }
    }

    IEnumerator Die()
    {
        yield return new WaitForSecondsRealtime(2);

        FindObjectOfType<GameSceneHandler>().LoadNextScene();
    }
}

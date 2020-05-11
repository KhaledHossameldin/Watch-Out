using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHandler : MonoBehaviour
{
    Vector3 moveDirection;
    float bulletSpeed;
    
    void Start()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        moveDirection = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        moveDirection.z = 0;
        moveDirection.Normalize();
        bulletSpeed = 10;
    }

    void Update()
    {
        transform.position = transform.position + moveDirection * bulletSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        if (collision.gameObject.tag.Equals("Zombie"))
        {
            collision.collider.GetComponent<ZombieHandler>().TakeDamage(10);
        }
    }
}

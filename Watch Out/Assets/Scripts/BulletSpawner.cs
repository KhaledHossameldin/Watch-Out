using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    Transform mainCharacterTransform;
    SpriteRenderer mainCharacterSpriteRenderer;
    SoundHandler soundHandler;
    float fireRate;
    float nextTimeToFire;
    int bulletsCounter;

    private void Start()
    {
        mainCharacterTransform = transform.GetComponentInParent<Transform>();
        mainCharacterSpriteRenderer = transform.GetComponentInParent<SpriteRenderer>();
        soundHandler = FindObjectOfType<SoundHandler>();
        fireRate = 10;
        nextTimeToFire = 0;
        bulletsCounter = 0;
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire && mainCharacterSpriteRenderer.sprite != null)
        {
            bulletsCounter++;

            Instantiate(bullet, transform.position, mainCharacterTransform.rotation);
            soundHandler.PlayShootSound(transform.position);

            if (bulletsCounter < 30)
            {
                nextTimeToFire = Time.time + (1 / fireRate); 
            }
            else
            {
                nextTimeToFire = Time.time + 2;
                bulletsCounter = 0;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPowerUpHandler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Main Character"))
        {
            collision.GetComponent<MainCharacterHandler>().AddHealth(20);
            Destroy(gameObject);
        }
    }
}

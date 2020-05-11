using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] GameObject heart;
    float timeBetweenSpawns = 30;

    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenSpawns);

            Vector2 heartCopyPosition = new Vector2(Random.Range(-4.3f, 4.3f), Random.Range(-1.9f, 1.9f));
            GameObject heartCopy = Instantiate(heart, heartCopyPosition, Quaternion.identity);
            Destroy(heartCopy, 30);
        }
    }
}

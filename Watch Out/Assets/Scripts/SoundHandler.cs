using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandler : MonoBehaviour
{
    [SerializeField] AudioClip shootSound;
	[SerializeField] AudioClip zombieSpawnSound;
	[SerializeField] AudioClip zombieBite;

	public void PlayShootSound(Vector3 bulletSpawnerPosition)
	{
		AudioSource.PlayClipAtPoint(shootSound, bulletSpawnerPosition, 0.5f);
	}

	public void PlayZombieSpawnSound(Vector3 zombieSpawnPosition)
	{
		AudioSource.PlayClipAtPoint(zombieSpawnSound, zombieSpawnPosition);
	}

	public void PlayZombieBite(Vector3 zombiePosition)
	{
		AudioSource.PlayClipAtPoint(zombieBite, zombiePosition);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehaviour : MonoBehaviour
{
	public GameObject toSpawn;
	public float potentialSpawnDelay;

    public AudioSource audioSource;
    public AudioClip[] glassShatterSounds;

    public void Spawn() {
    	StartCoroutine("SpawnWithDelay");
    }

    IEnumerator SpawnWithDelay() {
    	float delay = Random.value * potentialSpawnDelay;

    	yield return new WaitForSeconds(delay);

        Instantiate(toSpawn, transform.position, transform.rotation);
        GetComponent<ParticleSystem>().Play();
        Sounds.PlayRandomSound(audioSource, glassShatterSounds, 1);
    }
}

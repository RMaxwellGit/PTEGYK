using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSoundController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] periodicSounds;
    public AudioClip[] attackSounds;
    public float periodicVolume;
    public float attackVolume;
    public float maximumPeriodicSoundDelay;



    public float periodicNoiseCap;
    bool makesPeriodicNoise;


    public void PlayAttackSound() {
    	Sounds.PlayRandomSound(audioSource, attackSounds, attackVolume);
    }

    IEnumerator PlayPeriodicSounds() {
    	while(gameObject) {
    		float delay = Random.value * maximumPeriodicSoundDelay;

    		yield return new WaitForSeconds(delay);

    		Sounds.PlayRandomSound(audioSource, periodicSounds, periodicVolume);
    	}
    }

    void Start() {
        AssignPeriodicNoise();

        if (makesPeriodicNoise) {
        	StartCoroutine(PlayPeriodicSounds());
        }
    }

    //ideally there should also be a system to set non noisemaking zombies to make noise when a noise making zombie is killed and
    //we're below the cap again. For now waiting for them to spawn will work
    void AssignPeriodicNoise() {
        makesPeriodicNoise = true;

        //check how many zombies are active and making noise
        GameObject[] zombies = GameObject.FindGameObjectsWithTag("Enemy");
        float noiseMakers = 0;
        foreach (GameObject zombie in zombies) {
            if (zombie.GetComponent<ZombieSoundController>().GetMakePeriodicNoise()) {
                noiseMakers++;
            }
        }

        if (noiseMakers > periodicNoiseCap) {
            makesPeriodicNoise = false;
        }
    }

    bool GetMakePeriodicNoise() {
        return makesPeriodicNoise;
    }

    void SetMakePeriodicNoise(bool newValue) {
        makesPeriodicNoise = newValue;
    }
}
